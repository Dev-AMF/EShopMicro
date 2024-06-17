using Catalog.Api.UseCases.Products.GetProductById;
using Catalog.Api.UseCases.Products.GetProducts;
using Marten.Linq.QueryHandlers;

namespace Catalog.Api.UseCases.Products.GetProductsByCategory
{
    public record GetProductsByCategoryQuery(GetProductsByCategoryRequset req) : IQuery<GetProductsByCategoryResponse>;
    internal class GetProductsByCategoryQueryHandler : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResponse>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger<GetProductsByCategoryQueryHandler> _logger;

        public GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger)
        {
            _session = session;
            _logger = logger;
        }

        public async Task<GetProductsByCategoryResponse> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetProductsByCategoryQueryHandler ==> Called With {query.req}");

            var product = await _session.Query<Product>()
                                        .Where(p => p.Category.Contains(query.req.category))
                                        .ToListAsync();

            if (product == null)
            {
                throw new ProductNotFoundException($"Category");
            }
            var result = new GetProductsByCategoryResponse(product!);

            return result;
        }
    }


}
