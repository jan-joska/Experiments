using System.Collections.Generic;
using System.Linq;

namespace DomainModel
{
    public class IsDangerousRule : IRule<ArticleNumber>
    {
        private readonly IEnumerable<IRule<ArticleNumber>> _rules;

        public IsDangerousRule(IEnumerable<IRule<ArticleNumber>> rules)
        {
            _rules = rules;
        }

        public bool Satisfies(ArticleNumber input)
        {
            return _rules.Any(i => i.Satisfies(input));
        }
    }
}