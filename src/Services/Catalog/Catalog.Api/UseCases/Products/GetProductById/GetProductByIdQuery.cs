using Catalog.Api.UseCases.Products.GetProducts;

namespace Catalog.Api.UseCases.Products.GetProductById
{
    public record GetProductByIdQuery(GetProductByIdRequest req) : IQuery<GetProductByIdResponse>;

    internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
    {
        private readonly IDocumentSession _session;
       

        public GetProductByIdQueryHandler(IDocumentSession session)
        {
            _session = session;
          
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
          

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
