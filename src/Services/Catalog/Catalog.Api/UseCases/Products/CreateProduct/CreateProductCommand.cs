using Catalog.Api.UseCases.Products.GetProducts;

namespace Catalog.Api.UseCases.Products.CreateProduct
{
    public record CreateProductCommand(CreateProductRequest req): ICommand<CreateProductResponse>;

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        public CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommandHandler> logger)
        {
            _session = session;
            _logger = logger;
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommand query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeleteProductCommandHnadler ==> Called With {query.req}");

            //Bussiness Logic To Create a Product   

            var product = new Product
            {
                Name = query.req.Name,
                Category = query.req.Category,
                Description = query.req.Description,
                ImageFile = query.req.ImageFile,
                Price = query.req.Price,
            };

            _session.Store(product);
            await _session.SaveChangesAsync(cancellationToken);


            return new CreateProductResponse(product.Id);

        }
    }
}
