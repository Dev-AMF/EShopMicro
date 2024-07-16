namespace Basket.Api.Repository
{
    public class ChachedBasketRepository(IBasketRepository _NonChachRepository, IDistributedCache _redisCache) 
                 : IBasketRepository
    {

        public async Task<ShoppingCart> GetBasketAsync(string username, CancellationToken cancellationToken = default)
        {
            var basketFromCache = await _redisCache.GetStringAsync(username, cancellationToken);

            if (string.IsNullOrEmpty(basketFromCache))
            {
                var basketFromDb = await _NonChachRepository.GetBasketAsync(username, cancellationToken);

                await _redisCache.SetStringAsync(username,JsonSerializer.Serialize(basketFromDb),cancellationToken);

                return basketFromDb;

            }


            var deserializedBasketFromCache = JsonSerializer.Deserialize<ShoppingCart>(basketFromCache);

            return deserializedBasketFromCache!;
        }
        public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);

            await _NonChachRepository.StoreBasketAsync(basket, cancellationToken);

            return basket;
        }
        public async Task<bool> DeleteBasketAsync(string username, CancellationToken cancellationToken = default)
        {
            await _NonChachRepository.DeleteBasketAsync(username, cancellationToken);    

            await _redisCache.RemoveAsync(username, cancellationToken);

            return true;
        }
    }
}
