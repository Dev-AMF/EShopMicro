namespace Catalog.Api.UseCases.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.req.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.req.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.req.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.req.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }


}
