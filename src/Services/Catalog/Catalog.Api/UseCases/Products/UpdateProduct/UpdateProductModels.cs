namespace Catalog.Api.UseCases.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description,
                                          string ImageFile, decimal Price);

    public record UpdateProductResponse(bool isSuccess);
}
