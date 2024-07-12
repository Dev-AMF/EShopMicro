using Basket.Api.UseCases.DeleteBasket;
using Basket.Api.UseCases.StoreBasket;

namespace Basket.Api.EndPoints.Basket
{
    public class BasketCommandsController: BasketBaseController
    {
        private readonly IMediator _meditor;

        public BasketCommandsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpPost]
        public async Task<IResult> StoreBasket(StoreBasketRequest storeBasketRequest)
        {
            var command = new StoreBasketCommand(storeBasketRequest);

            var result = await _meditor.Send(command);

            return Results.Created($"GetBasketByUserName/{result.UserName}", result);
        }


        [HttpPost]
        public async Task<IResult> DeleteBasket(DeleteBasketRequest deleteBasketRequest)
        {
            var command = new DeleteBasketCommand(deleteBasketRequest);

            var result = await _meditor.Send(command);

            return Results.Ok(result);
        }
    }
}
