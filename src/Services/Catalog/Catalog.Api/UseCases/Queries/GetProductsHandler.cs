namespace Catalog.Api.UseCases.Queries
{
    public record GetProductsResult(IEnumerable<Product> Products);
    public record GetProductsQuery() : IQuery<GetProductsResult>;
    internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        {
            _session = session;
            _logger = logger;
        }

        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetProductsQueryHandler ==> Called With {query}");

            var products = await _session.Query<Product>().ToListAsync(cancellationToken);

            var result = new GetProductsResult(products);

            return result;
        }
    }
}
