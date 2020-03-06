using System;

namespace DomainModel
{
    public class OrderRepository : IOrderRepository
    {
        public IOrder Get(Guid id)
        {
            var o = new Order(id);
            o.AddItem(new Item(new ArticleNumber("XP","1234"), 5));
            return o;
        }

        public void Save(IOrder order)
        {
            
        }
    }
}