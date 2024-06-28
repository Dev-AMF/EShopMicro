namespace Basket.Api.EndPoints.Basket
{
    public class BasketQueriesController : BasketBaseController
    {
        private readonly IMediator _meditor;

        public BasketQueriesController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IResult> GetBasket([FromQuery] GetBasketRequest request)
        {
            var query = new GetBasketQuery(request);

            var result = await _meditor.Send(query);

            return Results.Ok(result);
        }
    }
}
