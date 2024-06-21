using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;
using System.Text;
using System.Windows.Input;

namespace BuildingBlocks.Behaviours
{
    public class ValidationBehaviour<TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse>
                                                           where TCommand : ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<TCommand>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TCommand>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TCommand request, RequestHandlerDelegate<TResponse> next, 
                                      CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TCommand>(request);

            var validationResults = await Task.WhenAll(
                                  _validators.Select(v 
                                                      => v.ValidateAsync(context, cancellationToken)));

            var errors = validationResults.Where(r => r.Errors.Any())
                                          .SelectMany(r => r.Errors)
                                          .ToList();

            if (errors.Any())
            {
                StringBuilder errorMessages = new StringBuilder();
                foreach (var error in errors)
                {
                    errorMessages.AppendLine(error.ErrorMessage);
                }
                throw new ValidationException(errorMessages.ToString());
            }

            return await next();
     
        }
    }
}
