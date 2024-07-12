
namespace Basket.Api.UseCases.DeleteBasket
{
    public record DeleteBasketCommand(DeleteBasketRequest DeleteBasketRequest):ICommand<DeleteBasketResponse>;
    internal class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResponse>
    {
        public async Task<DeleteBasketResponse> Handle(DeleteBasketCommand deleteBasketCommand, CancellationToken cancellationToken)
        {
           var commandParam = deleteBasketCommand.DeleteBasketRequest.UserName;

           var basketDeletionResult = await repository.DeleteBasketAsync(commandParam, cancellationToken);


           return new DeleteBasketResponse(basketDeletionResult);
        }
    }
}
