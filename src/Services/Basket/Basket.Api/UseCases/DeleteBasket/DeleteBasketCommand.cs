
namespace Basket.Api.UseCases.DeleteBasket
{
    public record DeleteBasketCommand(DeleteBasketRequest DeleteBasketRequest):ICommand<DeleteBasketResponse>;
    public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResponse>
    {
        public async Task<DeleteBasketResponse> Handle(DeleteBasketCommand deleteBasketCommand, CancellationToken cancellationToken)
        {
           return new DeleteBasketResponse(true);
        }
    }
}
