using System;

namespace DomainModel
{
    public class ArticleIsExplosiveRule : IRule<ArticleNumber>
    {
        public bool Satisfies(ArticleNumber input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return input.ArticlePrefix.StartsWith("EX");
        }
    }
}