namespace Order.Contracts.Events
{
    public enum OrderStatus
    {
        Created,
        WaitingForPayment,
        WaitingForDelivery,
        Canceled,
        Done
    }
}
