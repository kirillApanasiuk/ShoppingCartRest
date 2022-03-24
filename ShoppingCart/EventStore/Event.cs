namespace ShoppingCartApi.ShoppingCart.EventStore
{
    public record Event(
        long SequenceNumber,
        DateTimeOffset OccuredAt,
        string Name,
        object Content
        );

}
