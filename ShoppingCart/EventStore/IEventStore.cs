namespace ShoppingCartApi.ShoppingCart.EventStore
{
    public interface IEventStore
    {
        public void Notify(int[] productCatalogueIds);

        IEnumerable<Event> GetEvents(long firstEventSequenceNumber, long lastEventSequenceNumber);

        void Raise(string eventName, object content);
    }
}
