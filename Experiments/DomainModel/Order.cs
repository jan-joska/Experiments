using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel
{

    

    public class Order : IOrder
    {
        private Guid _customerId { get; set; }

        private static readonly MaximumTenArticlesRule MaximumTenArticlesRule = new MaximumTenArticlesRule();

        private static readonly IsDangerousRule IsDangerousRule = new IsDangerousRule(new IRule<ArticleNumber>[]
            {new ArticleIsVolatileRule(), new ArticleIsExplosiveRule()});

        private readonly List<OrderItem> _items = new List<OrderItem>();

        public Order(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public void AddItem(Item item)
        {
            if (IsDangerousRule.Satisfies(item.Article) && _items.Any(i => IsDangerousRule.Satisfies(i.ArticleNumber)))
                throw new InvalidOperationException(
                    $"Unable to add item {item.Article}. Order {Id} already contains at least one dangerous item. Create separate order for this article.");
            if (!MaximumTenArticlesRule.Satisfies(_items.Count))
                throw new InvalidOperationException(
                    $"Unable to add item. Order {Id} already contains maximum allowed amount of articles.");
            _items.Add(new OrderItem(item.Article, item.Count));
        }

        public void RemoveAllItems()
        {
            _items.Clear();
        }

        public decimal GetTotal()
        {
            var total = _items.Sum(i => i.Count);
            DomainEvents.Raise(new OrderSumCalculated(Id, total));
            return total;
        }

        public IEnumerable<Item> GetItems()
        {
            return _items.OrderBy(i => i.ArticleNumber.ArticlePrefix).Select(i => new Item(i.ArticleNumber, i.Count));
        }

        public bool CanAddDangerousItem
        {
            get { return _items.Any(i => IsDangerousRule.Satisfies(i.ArticleNumber)); }
        }

        public void AttachToCustomer(Guid customerId)
        {
            this._customerId = customerId;
        }

        public Guid CustomerId => _customerId;
    }
}