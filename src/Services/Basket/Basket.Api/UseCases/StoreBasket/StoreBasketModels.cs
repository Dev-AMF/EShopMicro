namespace Basket.Api.UseCases.StoreBasket
{

    public record StoreBasketRequest(string UserName)
    {
        public List<StoreBasketItem> Items { get; init; } = new();
        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);

        public override string ToString()
        {
            var itemsString = string.Join(" ,, ", Items.Select(item => item.ToString()));
            return $"UserName: {UserName}, Items: [{itemsString}], TotalPrice: {TotalPrice:C}";
        }
    }
    public record StoreBasketItem
    {
        public int Quantity { get; init; } = default!;
        public string Color { get; init; } = default!;
        public decimal Price { get; init; } = default!;
        public Guid ProductId { get; init; } = default!;
        public string ProductName { get; init; } = default!;

        public override string ToString() => $"Product: {ProductName}, Color: {Color}, Quantity: {Quantity}, Price: {Price:C}, ProductId: {ProductId}";
    }
    public record StoreBasketResponse(string UserName);
}
