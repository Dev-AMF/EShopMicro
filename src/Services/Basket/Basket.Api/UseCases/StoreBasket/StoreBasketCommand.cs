namespace Basket.Api.UseCases.StoreBasket
{
    public record StoreBasketCommand(StoreBasketRequest StoreBasketRequest) : ICommand<StoreBasketResponse>;

    public class StoreBasketHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand,StoreBasketResponse>
    {
        public async Task<StoreBasketResponse> Handle(StoreBasketCommand storeBasketCommand, CancellationToken cancellationToken)
        {
            var dbModel = storeBasketCommand.StoreBasketRequest.Adapt<ShoppingCart>(); 

            var basketToBeStored = await repository.StoreBasketAsync(dbModel, cancellationToken);  

            var storeBasktetResponse = basketToBeStored.Adapt<StoreBasketResponse>();

            return storeBasktetResponse;
        }
    }
}
