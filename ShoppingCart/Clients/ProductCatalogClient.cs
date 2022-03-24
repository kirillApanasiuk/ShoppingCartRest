using System.Net.Http.Headers;
using System.Text.Json;

namespace ShoppingCartApi.ShoppingCart.Clients
{
    public class ProductCatalogClient:IProductCatalogClient
    {
        private readonly HttpClient client;
        private static string productCatalogBaseUrl = @"https://git.io/JeHiE";
        private static string getProductPathTemplate = "?productIds=[{0}]";

        public ProductCatalogClient(HttpClient client)
        {
            client.BaseAddress = new Uri(productCatalogBaseUrl);

            client
                .DefaultRequestHeaders
                .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.client = client;
        }
        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems(int[] productIds)
        {
            var httpResponse =  await RequestProductFromProductCatalog(productIds);

            return await ResponseToShoppingCartItem(httpResponse);
        }

        public async Task<HttpResponseMessage> RequestProductFromProductCatalog(int[] productCatalogIds)
        {
            var productsResource = string.Format(getProductPathTemplate, string.Join(",", productCatalogIds));

            //TODO figure out with products resource and add to GetAsync method productsResource query

            return await this.client.GetAsync("");
        }

        private static async Task<IEnumerable<ShoppingCartItem>> ResponseToShoppingCartItem(HttpResponseMessage httpResponse)
        {
            httpResponse.EnsureSuccessStatusCode();

            var products = await JsonSerializer.DeserializeAsync<List<ShoppingCartItem>>(
                await httpResponse.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

            return products.Select(product => new ShoppingCartItem(product.ProductCatalogueId,product.ProductName,product.Description,product.Price));


        }
    }
}
