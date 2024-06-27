namespace Catalog.Api.UseCases.Products.CreateProduct
{
    public record CreateProductCommand(CreateProductRequest req): ICommand<CreateProductResponse>;

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IDocumentSession _session;
     
        public CreateProductCommandHandler(IDocumentSession session)
        {
            _session = session;
  
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
          


          //Bussiness Logic To Create a Product   

          var product = new Product
            {
                Name = command.req.Name,
                Category = command.req.Category,
                Description = command.req.Description,
                ImageFile = command.req.ImageFile,
                Price = command.req.Price,
            };

            _session.Store(product);
            await _session.SaveChangesAsync(cancellationToken);


            return new CreateProductResponse(product.Id);

        }
    }
}
