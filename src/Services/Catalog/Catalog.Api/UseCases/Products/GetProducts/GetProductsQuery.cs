namespace Catalog.Api.UseCases.Products.GetProducts
{
    public record GetProductsQuery(GetProductsRequest req) : IQuery<GetProductsResponse>;
    internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResponse>
    {
        private readonly IDocumentSession _session;


        public GetProductsQueryHandler(IDocumentSession session)
        {
            _session = session;

        }

        public async Task<GetProductsResponse> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var pageSize = query.req.PageSize ?? 10;
            var pageNumber = query.req.PageNumber ?? 1;


            var products = await _session
                                .Query<Product>()
                                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);

            var result = new GetProductsResponse(products);

            return result;
        }
    }
}
