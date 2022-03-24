﻿namespace ShoppingCartApi.ShoppingCart
{
    public class ShoppingCartStore:IShoppingCartStore
    {
        private static readonly Dictionary<int, ShoppingCart> Database = new Dictionary<int, ShoppingCart>();
        public ShoppingCart Get(int userId)
        {
            return Database.ContainsKey(userId) ? Database[userId] : new ShoppingCart(userId);
        }

        public void Save(ShoppingCart shoppingCart)
        {
            Database[shoppingCart.UserId] = shoppingCart;
        }
    }
}
