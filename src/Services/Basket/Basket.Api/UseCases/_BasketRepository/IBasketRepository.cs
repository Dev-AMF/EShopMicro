﻿namespace Basket.Api.UseCases._BasktRepository
{
    public interface IBasketRepository
    {
        Task<bool> DeleteBasketAsync(string username, CancellationToken cancellationToken = default);
        Task<ShoppingCart> GetBasketAsync(string username, CancellationToken cancellationToken = default);
        Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default);
    }
}
