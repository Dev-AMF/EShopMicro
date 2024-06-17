using Catalog.Api.UseCases.Products.CreateProduct;

namespace Catalog.Api.UseCases.Products.GetProducts
{
    public record GetProductsResponse(IEnumerable<Product> Products);

}
