using Basket.Api.UseCases.StoreBasket;

namespace Basket.Api.UseCases.SaharedModels
{
    public record BasketCartRequest(string UserName)
    {

        public List<BasketCartItem> Items { get; init; } = new();
        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);

    }
    public record BasketCartResponse
    {
        public string UserName { get; set; } = default!;
        public List<BasketCartItem> Items { get; init; } = new();
        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);
    }


    public record BasketCartItem
    {
        public int Quantity { get; init; } = default!;
        public string Color { get; init; } = default!;
        public decimal Price { get; init; } = default!;
        public Guid ProductId { get; init; } = default!;
        public string ProductName { get; init; } = default!;

        public override string ToString() => $"Product: {ProductName}, Color: {Color}, Quantity: {Quantity}, Price: {Price:C}, ProductId: {ProductId}";
    }
}
