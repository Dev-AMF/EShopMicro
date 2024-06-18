namespace Catalog.Api.UseCases.Products.IValidators
{
    public interface ICommandValidator<TRequest> 
    {
        Task<ValidationResult> ValidateAsync(TRequest request);
    }
}
