﻿namespace Basket.Api.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new ();
        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);

        public ShoppingCart()//====> Required For Mapping Libraries
        {
                
        }
        public ShoppingCart(string username)
        {
           UserName = username;
        }
    }
}
