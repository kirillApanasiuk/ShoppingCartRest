namespace ShoppingCartApi.ShoppingCart.EventStore
{
    public class EventDatabase : IEventDatabase
    {
        private readonly List<Event> _events;
        private readonly int _lastSequenceNumber;

        public EventDatabase()
        {
            _events = new List<Event>();
            _lastSequenceNumber = 0;
        }
        public void Add(Event newEvent)
        {
           _events.Add(newEvent);
        }

        public IEnumerable<Event> GetEvents()
        {
            return _events;
        }

        public int NextSequenceNumber()
        {
            return 0;
        }
    }
}
