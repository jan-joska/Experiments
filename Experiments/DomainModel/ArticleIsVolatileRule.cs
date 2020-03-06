using System;

namespace DomainModel
{
    public class ArticleIsVolatileRule : IRule<ArticleNumber>
    {
        public bool Satisfies(ArticleNumber input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return input.ArticlePrefix.StartsWith("FI");
        }
    }
}