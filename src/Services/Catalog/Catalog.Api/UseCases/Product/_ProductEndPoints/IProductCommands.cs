namespace Catalog.Api.UseCases.Products._ProductsEndPoints
{
    public interface IProductCommands
    {
        Task<IResult> CreatePorduct(CreateProductRequest request);
        Task<IResult> UpdatePorduct(UpdateProductRequest request);
        Task<IResult> DeletePorduct(DeleteProductRequest request);
    }
}
