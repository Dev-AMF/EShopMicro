namespace Catalog.Api.UseCases.Products.ProductsEndPoints
{

    public class ProductsQueriesController : ProductBaseController
    {
        private readonly IMediator _meditor;
        public ProductsQueriesController(IMediator mediator)
        {
            _meditor = mediator;
        }


        [HttpGet]
        public async Task<IResult> GetProducts([FromQuery] GetProductsRequest request)
        {
            var query = new GetProductsQuery(request);

            var result = await _meditor.Send(query);

            var response = result.Adapt<GetProductsResponse>();

            return Results.Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetProductById(Guid id)
        {
            var query = new GetProductByIdQuery(new GetProductByIdRequest(id));

            var result = await _meditor.Send(query);

            var response = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(response);
        }

        [HttpGet("{category}")]
        public async Task<IResult> GetProductByCategory(string category)
        {
            var query = new GetProductsByCategoryQuery(new GetProductsByCategoryRequset(category));

            var result = await _meditor.Send(query);

            var response = result.Adapt<GetProductsByCategoryResponse>();

            return Results.Ok(response);
        }
    }
}
