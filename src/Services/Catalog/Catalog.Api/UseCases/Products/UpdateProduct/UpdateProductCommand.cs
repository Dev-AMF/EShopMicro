
using Catalog.Api.UseCases.Products.GetProducts;

namespace Catalog.Api.UseCases.Products.UpdateProduct
{
    public record UpdateProductCommand(UpdateProductRequest req) : ICommand<UpdateProductResponse>;
    internal class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductResponse>
    {
        private readonly IDocumentSession _session;
      

        public UpdateProductCommandHandler(IDocumentSession session)
        {
            _session = session;

        }

        public async Task<UpdateProductResponse> Handle(UpdateProductCommand query, CancellationToken cancellationToken)
        {
            

            var product = await _session.LoadAsync<Product>(query.req.Id, cancellationToken);

            if (product == null)
            {
                throw new ProductNotFoundException("Id");
            }


            product.Name = query.req.Name;
            product.Description = query.req.Description;
            product.Price = query.req.Price;
            product.Category = query.req.Category;
            product.ImageFile = query.req.ImageFile;


            _session.Update(product);
            await _session.SaveChangesAsync(cancellationToken);


            var result = new UpdateProductResponse(true);


            return result;
        }
    }
}
