using System;

namespace DomainModel
{
    public class OrderSumCalculated : IDomainEvent
    {
        public OrderSumCalculated(Guid orderId, int total)
        {
            OrderId = orderId;
            Total = total;
        }
        public Guid OrderId { get; }
        public int Total { get; }

        public override string ToString()
        {
            return $"{nameof(OrderId)}: {OrderId}, {nameof(Total)}: {Total}";
        }
    }
}