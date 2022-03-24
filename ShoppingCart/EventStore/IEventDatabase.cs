namespace ShoppingCartApi.ShoppingCart.EventStore
{
    public interface IEventDatabase
    {
        IEnumerable<Event> GetEvents();
        int NextSequenceNumber();
        void Add(Event newEvent);
    }
}
