

namespace Basket.Api.UseCases.GetBasket
{
    public record GetBasketQuery(GetBasketRequest req) : IQuery<GetBasketResponse>;

    internal class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResponse>
    {
        public async Task<GetBasketResponse> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            return new GetBasketResponse(new ShoppingCart("SW"));
        }
    }

}
