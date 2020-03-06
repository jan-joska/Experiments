using System;
using System.Collections.Generic;

namespace DomainModel
{

    public class CustomerRenamedEventHandler
    {
        public CustomerRenamedEventHandler(OrderFactory orderFactory, )
        {
            
        }
    }

    public interface IOrder
    {
        Guid Id { get; }
        void AddItem(Item item);
        void RemoveAllItems();
        decimal GetTotal();
        IEnumerable<Item> GetItems();
        bool CanAddDangerousItem { get; }
        void AttachToCustomer(Guid customerId);
        Guid CustomerId { get; }
    }
}