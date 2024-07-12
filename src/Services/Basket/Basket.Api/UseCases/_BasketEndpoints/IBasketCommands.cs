namespace Basket.Api.UseCases._BasketEndpoints
{
    public interface IBasketCommands
    {
        Task<IResult> StoreBasket(StoreBasketRequest storeBasketRequest);

        Task<IResult> DeleteBasket(DeleteBasketRequest deleteBasketRequest);
    }
}
