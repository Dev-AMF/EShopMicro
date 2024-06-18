using System.Text;

namespace Catalog.Api.UseCases.Products.IValidators
{
    public class CommandValidator<TRequest> : ICommandValidator<TRequest>
    {
        private readonly IValidator<TRequest> _validator;

        public CommandValidator(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<ValidationResult> ValidateAsync(TRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            if (errors != null)
            {
                StringBuilder errorMessages = new StringBuilder();
                foreach (var error in errors)
                {
                    errorMessages.AppendLine(error);
                }
                throw new ValidationException(errorMessages.ToString());
            }

            return validationResult;
        }
    }
}
