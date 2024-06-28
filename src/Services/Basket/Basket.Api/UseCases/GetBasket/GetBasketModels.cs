namespace Basket.Api.UseCases.GetBasket
{
    public record GetBasketRequest(string UserName);
    public record GetBasketResponse(ShoppingCart cart);
}
