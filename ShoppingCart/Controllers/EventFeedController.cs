using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.ShoppingCart.EventStore;

namespace ShoppingCartApi.ShoppingCart.Controllers
{
    [Route("/events")]
    [ApiController]
    public class EventFeedController : ControllerBase
    {
        private readonly IEventStore eventStore;

        public EventFeedController(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        [HttpGet]
        public Event[] Get(
            [FromQuery] long start,
            [FromQuery] long end = long.MaxValue
            )
        {
            var events = this.eventStore.GetEvents(start, end).ToArray();

            return events;
        }
    }
}
