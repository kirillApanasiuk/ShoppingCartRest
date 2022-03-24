namespace ShoppingCartApi.ShoppingCart.Clients
{
    public interface IProductCatalogClient
    {
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems(int[] productIds);
    }
}
