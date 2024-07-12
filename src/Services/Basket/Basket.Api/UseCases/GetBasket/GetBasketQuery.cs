namespace Basket.Api.UseCases.GetBasket
{
    public record GetBasketQuery(GetBasketRequest GetBasketRequest) : IQuery<GetBasketResponse>;

    internal class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResponse>
    {
        public async Task<GetBasketResponse> Handle(GetBasketQuery getBasketQuery, CancellationToken cancellationToken)
        {
            var queryParam = getBasketQuery.GetBasketRequest.UserName;

            var fetchedBasket = await repository.GetBasketAsync(queryParam, cancellationToken);

            var getBasketResponse = fetchedBasket.Adapt<GetBasketResponse>();

            return getBasketResponse;
        }
    }

}
