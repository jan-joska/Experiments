using System;

namespace DomainModel
{
    public class OrderItem
    {
        public ArticleNumber ArticleNumber { get; }
        public int Count { get; }

        internal OrderItem (ArticleNumber articleNumber, int count)
        {
            ArticleNumber = articleNumber;
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Count = count;
        }

        protected bool Equals(OrderItem other)
        {
            return Equals(ArticleNumber, other.ArticleNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderItem) obj);
        }

        public override int GetHashCode()
        {
            return (ArticleNumber != null ? ArticleNumber.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return $"{nameof(ArticleNumber)}: {ArticleNumber}, {nameof(Count)}: {Count}";
        }
    }
}