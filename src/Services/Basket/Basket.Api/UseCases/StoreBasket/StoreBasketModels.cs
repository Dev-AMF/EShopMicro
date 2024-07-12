namespace Basket.Api.UseCases.StoreBasket
{
    public record StoreBasketRequest(string UserName, List<ShoppingCartItem> Items)
    {
        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);
    }
    public record StoreBasketResponse(string UserName);
}
