namespace Catalog.Api.UseCases.Products.GetProductsByCategory
{
    public record GetProductsByCategoryRequset(string category);
    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);
}
