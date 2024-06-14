namespace Catalog.Api.UseCases.Products
{
    public record CreateProductResult(Guid id);
    
    public record CreateProductCommand(string Name, List<string> Category, string Description,
                                       string ImageFile, decimal Price) 
                                                                    : ICommand<CreateProductResult>;
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
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


            return new CreateProductResult(Guid.NewGuid());
            
        }
    }
}
