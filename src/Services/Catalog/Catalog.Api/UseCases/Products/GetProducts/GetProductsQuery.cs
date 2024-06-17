namespace Catalog.Api.UseCases.Products.GetProducts
{
    public record GetProductsQuery() : IQuery<GetProductsResponse>;
    internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResponse>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        {
            _session = session;
            _logger = logger;
        }

        public async Task<GetProductsResponse> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetProductsQueryHandler ==> Called.");

            var products = await _session.Query<Product>().ToListAsync(cancellationToken);

            var result = new GetProductsResponse(products);

            return result;
        }
    }
}
