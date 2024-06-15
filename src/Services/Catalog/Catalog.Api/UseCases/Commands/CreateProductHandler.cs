namespace Catalog.Api.UseCases.Commands
{
    public record CreateProductResult(Guid id);

    public record CreateProductCommand(string Name, List<string> Category, string Description,
                                       string ImageFile, decimal Price)
                                                                    : ICommand<CreateProductResult>;
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IDocumentSession _session;

        public CreateProductCommandHandler(IDocumentSession session)
        {
            _session = session;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Bussiness Logic To Create a Product   

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            _session.Store(product);
            await _session.SaveChangesAsync(cancellationToken);


            return new CreateProductResult(product.Id);

        }
    }
}
