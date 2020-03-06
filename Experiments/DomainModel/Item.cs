namespace DomainModel
{
    public class Item
    {
        public Item(ArticleNumber article, int count)
        {
            Article = article;
            Count = count;
        }
        public ArticleNumber Article { get; }
        public int Count { get; }

        public override string ToString()
        {
            return $"{nameof(Article)}: {Article}, {nameof(Count)}: {Count}";
        }
    }
}