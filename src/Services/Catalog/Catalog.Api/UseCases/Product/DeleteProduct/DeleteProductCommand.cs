using Catalog.Api.UseCases.Products.GetProducts;

namespace Catalog.Api.UseCases.Products.DeleteProduct
{
    public record DeleteProductCommand(DeleteProductRequest req) : ICommand<DeleteProductResponse>;


    internal class DeleteProductCommandHnadler : ICommandHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IDocumentSession _session;


        public DeleteProductCommandHnadler(IDocumentSession session)
        {
            _session = session;

        }

        public async Task<DeleteProductResponse> Handle(DeleteProductCommand query, CancellationToken cancellationToken)
        {
          

            _session.Delete<Product>(query.req.id);
            await _session.SaveChangesAsync(cancellationToken);

            var response = new DeleteProductResponse(true);

            return response;
        }
    }
}
