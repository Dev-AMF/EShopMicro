namespace Basket.Api.Repository
{
    public class BasketRepository(IDocumentSession _session) : IBasketRepository
    {
        public async Task<bool> DeleteBasketAsync(string username, CancellationToken cancellationToken = default)
        {
           _session.Delete<ShoppingCart>(username);
            await
          _session.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<ShoppingCart> GetBasketAsync(string username, CancellationToken cancellationToken = default)
        {
            var basket = await _session.LoadAsync<ShoppingCart>(username, cancellationToken);

            return basket is null ? throw new BasketNotFoundException(username) : basket;
        }

        public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            _session.Store(basket);
             await 
            _session.SaveChangesAsync(cancellationToken);
            
            return basket;
        }
    }
}
