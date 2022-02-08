namespace Writer.Domain.Events;

public record OrderCanceled : EventRoot
{
    public override EventType Type => throw new NotImplementedException();
}

