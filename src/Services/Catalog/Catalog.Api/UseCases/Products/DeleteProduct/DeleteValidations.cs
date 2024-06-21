namespace Catalog.Api.UseCases.Products.DeleteProduct
{
    public class DeleteProductsValidation : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductsValidation()
        {
            RuleFor(command => command.req.id).NotEmpty().WithMessage("Product ID is required");
        }
    }
}
