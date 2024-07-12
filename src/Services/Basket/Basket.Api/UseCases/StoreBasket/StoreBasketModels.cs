using Basket.Api.UseCases.SaharedModels;

namespace Basket.Api.UseCases.StoreBasket
{

    public record StoreBasketRequest(string UserName) : BasketCartRequest(UserName)
    {
        public override string ToString()
        {
            var itemsString = string.Join(" ,, ", Items.Select(item => item.ToString()));
            return $"UserName: {UserName}, Items: [{itemsString}], TotalPrice: {TotalPrice:C}";
        }
    }

    public record StoreBasketResponse(string UserName);
}
