using System.Text;

namespace BuildingBlocks.Behaviours
{
    public class ValidationBehaviour<TCommand, TResponse>: //InheritsFrom:
                                                           IPipelineBehavior<TCommand, TResponse>
                                                           //With Condition
                                                            where TCommand : ICommand<TResponse>
    {
        //Prperty for DI
        private readonly IEnumerable<IValidator<TCommand>> _validators;

        //CTOR Part
        #region CTOR
        public ValidationBehaviour(IEnumerable<IValidator<TCommand>> validators)
        {
            _validators = validators;
        }
        #endregion


        //Actual Handle Logic
        public async Task<TResponse> Handle(TCommand request,
                                            RequestHandlerDelegate<TResponse> next,
                                            CancellationToken cancellationToken)

        {
            var context = 
                    new ValidationContext<TCommand>(request);


            var validationResults = await 
                            Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));


            var errors = 
                validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (errors.Any())
                throw new ValidationException(errors);

            return await next();
     
        }
    }
}
