namespace Catalog.Api.UseCases.Products._ProductsEndPoints
{
    public interface IProductQueries
    {
        Task<IResult> GetProducts(GetProductsRequest request);
        Task<IResult> GetProductById(Guid id);
        Task<IResult> GetProductByCategory(string category);
    }
}
