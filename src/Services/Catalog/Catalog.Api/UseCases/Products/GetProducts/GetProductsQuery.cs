namespace Catalog.Api.UseCases.Products.GetProducts
{
    public record GetProductsQuery() : IQuery<GetProductsResponse>;
    internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResponse>
    {
        private readonly IDocumentSession _session;
    

        public GetProductsQueryHandler(IDocumentSession session)
        {
            _session = session;
       
        }

        public async Task<GetProductsResponse> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
         

            var products = await _session.Query<Product>().ToListAsync(cancellationToken);

            var result = new GetProductsResponse(products);

            return result;
        }
    }
}
