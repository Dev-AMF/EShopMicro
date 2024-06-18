using Catalog.Api.UseCases.Products.GetProducts;
using Catalog.Api.UseCases.Products.IValidators;

namespace Catalog.Api.UseCases.Products.CreateProduct
{
    public record CreateProductCommand(CreateProductRequest req): ICommand<CreateProductResponse>;

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly ICommandValidator<CreateProductRequest> _validator;
        public CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommandHandler> logger,
                                           ICommandValidator<CreateProductRequest> validator)
        {
            _session = session;
            _logger = logger;
            _validator = validator;
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommand query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeleteProductCommandHnadler ==> Called With {query.req}");

            await _validator.ValidateAsync(query.req);

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
