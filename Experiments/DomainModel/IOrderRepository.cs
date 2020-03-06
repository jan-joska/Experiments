using System;

namespace DomainModel
{
    public interface IOrderRepository
    {
        IOrder Get(Guid id);

        void Save(IOrder order);
    }
}