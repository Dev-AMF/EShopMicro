namespace Basket.Api.UseCases._BasketEndpoints
{
    public interface IBasketQueries
    {
        Task<IResult> GetBasket(GetBasketRequest request);
    }
}
