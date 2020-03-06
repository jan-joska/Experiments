using System;

namespace DomainModel
{
    public class ArticleNumber
    {
        public string ArticlePrefix { get; }
        public string FourDigitCode { get; }


        public ArticleNumber(string articlePrefix, string fourDigitCode)
        {
            if (string.IsNullOrEmpty(articlePrefix))
                throw new ArgumentException("Value cannot be null or empty.", nameof(articlePrefix));
            if (string.IsNullOrEmpty(fourDigitCode))
                throw new ArgumentException("Value cannot be null or empty.", nameof(fourDigitCode));
            if (fourDigitCode.Length != 4)
            {
                throw new ArgumentOutOfRangeException();
            }
            ArticlePrefix = articlePrefix.ToUpper();
            FourDigitCode = fourDigitCode.ToUpper();
        }

        public bool PrefixStartsWith(string input)
        {
            return ArticlePrefix.StartsWith(input, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{ArticlePrefix}-{FourDigitCode}";
        }

        protected bool Equals(ArticleNumber other)
        {
            return string.Equals(ArticlePrefix, other.ArticlePrefix) && string.Equals(FourDigitCode, other.FourDigitCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ArticleNumber) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((ArticlePrefix != null ? ArticlePrefix.GetHashCode() : 0) * 397) ^ (FourDigitCode != null ? FourDigitCode.GetHashCode() : 0);
            }
        }
    }
}