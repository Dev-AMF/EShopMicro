using Catalog.Api.UseCases.Commands;

namespace Catalog.Api.UseCases.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description,
                                      string ImageFile, decimal Price);

    public record CreateProductResponse(Guid id);

    [ApiController]
    [Route("[controller]")]
    public partial class ProductsController : ControllerBase
    {
        private readonly IMediator _meditor;
        public ProductsController(IMediator mediator)
        {
            _meditor = mediator;
        }


        [HttpPost]
        public async Task<IResult> CreatePorduct(CreateProductRequest request)
        {
            var command = request.Adapt<CreateProductCommand>();

            var result = await _meditor.Send(command);

            var response = result.Adapt<CreateProductResponse>();

            return Results.Created($"products/{response.id}", response);
        }
    }


}
