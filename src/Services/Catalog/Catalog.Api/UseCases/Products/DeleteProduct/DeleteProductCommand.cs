using Catalog.Api.UseCases.Products.GetProducts;

namespace Catalog.Api.UseCases.Products.DeleteProduct
{
    public record DeleteProductCommand(DeleteProductRequest req) : ICommand<DeleteProductResponse>;


    internal class DeleteProductCommandHnadler : ICommandHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger<DeleteProductCommandHnadler> _logger;

        public DeleteProductCommandHnadler(IDocumentSession session, ILogger<DeleteProductCommandHnadler> logger)
        {
            _session = session;
            _logger = logger;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductCommand query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeleteProductCommandHnadler ==> Called With {query.req}");

            _session.Delete<Product>(query.req.id);
            await _session.SaveChangesAsync(cancellationToken);

            var response = new DeleteProductResponse(true);

            return response;
        }
    }
}
