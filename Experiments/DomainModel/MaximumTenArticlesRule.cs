namespace DomainModel
{
    public class MaximumTenArticlesRule : IRule<int>
    {
        public bool Satisfies(int input)
        {
            return input <= 10;
        }
    }
}