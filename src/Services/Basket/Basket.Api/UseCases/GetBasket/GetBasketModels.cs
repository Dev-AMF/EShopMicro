

namespace Basket.Api.UseCases.GetBasket
{
    public record GetBasketRequest(string UserName);
    public record GetBasketResponse : BasketCartResponse
    {
        public override string ToString()
        {
            var itemsString = string.Join(" ,, ", Items.Select(item => item.ToString()));
            return $"UserName: {UserName}, Items: [{itemsString}], TotalPrice: {TotalPrice:C}";
        }
    }
}
