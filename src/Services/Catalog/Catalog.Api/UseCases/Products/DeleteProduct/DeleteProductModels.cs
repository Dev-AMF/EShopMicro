namespace Catalog.Api.UseCases.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid id);
    public record DeleteProductResponse(bool IsSuccess);

}
