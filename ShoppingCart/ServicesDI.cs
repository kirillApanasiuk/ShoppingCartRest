using Polly;
using ShoppingCartApi.ShoppingCart.Clients;
using ShoppingCartApi.ShoppingCart.EventStore;

namespace ShoppingCartApi.ShoppingCart
{
    public static class ServicesDI
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection descriptors)
        {
            descriptors.AddTransient<IShoppingCartStore, ShoppingCartStore>();
            descriptors.AddTransient<IEventStore, ShoppingCartApi.ShoppingCart.EventStore.Realization.EventStore>();
            descriptors.AddHttpClient<IProductCatalogClient, ProductCatalogClient>().
                AddTransientHttpErrorPolicy(p =>
                                            p.WaitAndRetryAsync(
                                              3,
                                              attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)))
                                            );

            descriptors.AddTransient<IEventDatabase, EventDatabase>();
            return descriptors;
        }
    }
}



