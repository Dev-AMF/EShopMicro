namespace Catalog.Api.UseCases.Products.UpdateProduct
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            RuleFor(command => command.req.Id).NotEmpty().WithMessage("Product ID is required");

            RuleFor(command => command.req.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");

            RuleFor(command => command.req.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
