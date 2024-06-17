using Catalog.Api.UseCases.Products.GetProducts;

namespace Catalog.Api.UseCases.Products.GetProductById
{
    public record GetProductByIdQuery(GetProductByIdRequest req) : IQuery<GetProductByIdResponse>;

    internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        {
            _session = session;
            _logger = logger;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetProductByIdQueryHandler ==> Called With {query.req}");

            var product = await _session.LoadAsync<Product>(query.req.id,cancellationToken);

            if (product == null)
            {
                throw new ProductNotFoundException("Id");
            }
            var result = new GetProductByIdResponse(product!);
            
            return result;
        }
    }
}
