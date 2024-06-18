namespace Catalog.Api.UseCases.Products.IValidators
{
    public interface IQueryValidation<TRequest>
    {
        Task<ValidationResult> Validate(TRequest request);
    }
}
