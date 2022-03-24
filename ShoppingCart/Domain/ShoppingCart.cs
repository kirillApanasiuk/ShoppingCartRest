using ShoppingCartApi.ShoppingCart.EventStore;

namespace ShoppingCartApi.ShoppingCart
{
    public class ShoppingCart
    {
        private readonly HashSet<ShoppingCartItem> items = new();
        public int UserId { get; }
        public IEnumerable<ShoppingCartItem> Items => this.items;
        public ShoppingCart(int userId) => this.UserId = userId;

        public void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItems, IEventStore eventStore)
        {
            foreach (var item in shoppingCartItems)
            {
                this.items.Add(item);

                eventStore.Raise("ShoppingCartItemAdded",new {UserId,item});
            }
        }

        public void RemoveItems(int[] productCatalogueIds, IEventStore eventStore) 
        {

            this.items.RemoveWhere(x => productCatalogueIds.Contains(x.ProductCatalogueId));
            eventStore.Raise("ShoppingCartItemDeleted",new {UserId, productCatalogueIds });
        }
    }
}
