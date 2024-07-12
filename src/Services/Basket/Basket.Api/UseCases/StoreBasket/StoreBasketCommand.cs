namespace Basket.Api.UseCases.StoreBasket
{
    public record StoreBasketCommand(StoreBasketRequest StoreBasketRequest) : ICommand<StoreBasketResponse>;

    public class StoreBasketHandler : ICommandHandler<StoreBasketCommand,StoreBasketResponse>
    {
        public async Task<StoreBasketResponse> Handle(StoreBasketCommand storeBasketCommand, CancellationToken cancellationToken)
        {
            ShoppingCart cart = storeBasketCommand.StoreBasketRequest.Adapt<ShoppingCart>();


            return new StoreBasketResponse("true");
        }
    }
}
