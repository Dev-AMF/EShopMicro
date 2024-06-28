namespace Catalog.Api.UseCases.Products.GetProductById
{
  public record GetProductByIdRequest(Guid id);

 public record GetProductByIdResponse(Product Product);
}
