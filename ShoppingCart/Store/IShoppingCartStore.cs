namespace ShoppingCartApi.ShoppingCart;

public interface IShoppingCartStore
{
    public ShoppingCart Get(int userId);
    void Save(ShoppingCart shoppingCart);
}