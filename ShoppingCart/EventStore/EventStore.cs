namespace ShoppingCartApi.ShoppingCart.EventStore.Realization
{
    public class EventStore:IEventStore
    {
        private readonly IEventDatabase eventDatabase;

        public EventStore(IEventDatabase eventDatabase)
        {
            this.eventDatabase = eventDatabase;
        }
        public IEnumerable<Event> GetEvents(long firstEventSequenceNumber, long lastEventSequenceNumber)
        {
            return this.eventDatabase.GetEvents()
                .Where(e => e.SequenceNumber >= firstEventSequenceNumber && 
                            e.SequenceNumber <= lastEventSequenceNumber)
                .OrderBy(e => e.SequenceNumber);
        }

        public void Notify(int[] productCatalogueIds)
        {
            Console.WriteLine("Mock implementation of notifying event store");
        }

        public void Raise(string eventName, object content)
        {
            var seqNumber = eventDatabase.NextSequenceNumber();

            eventDatabase.Add(new Event(seqNumber, DateTime.UtcNow, eventName, content));
        }
    }
}
