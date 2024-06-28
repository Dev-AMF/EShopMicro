namespace Catalog.Api.UseCases.Products.ProductsEndPoints
{

    public class ProductsCommandsController: ProductBaseController
    {
        private readonly IMediator _meditor;

        public ProductsCommandsController(IMediator mediator)
        {
            _meditor = mediator;
        }


        [HttpPost]
        public async Task<IResult> CreatePorduct(CreateProductRequest request)
        {
            var command = new CreateProductCommand(request);

            var result = await _meditor.Send(command);

            return Results.Created($"GetProductById/{result.id}", result);
        }

        [HttpPost]
        public async Task<IResult> UpdatePorduct(UpdateProductRequest request)
        {
            var command = new UpdateProductCommand(request);

            var result = await _meditor.Send(command);

            return Results.Ok(result);
        }

        [HttpPost]
        public async Task<IResult> DeletePorduct(DeleteProductRequest request)
        {
            var command = new DeleteProductCommand(request);

            var result = await _meditor.Send(command);

            return Results.Ok(result);
        }
    }
}
