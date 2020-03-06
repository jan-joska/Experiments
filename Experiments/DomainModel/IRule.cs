namespace DomainModel
{
    public interface IRule<T>
    {
        bool Satisfies(T input);
    }
}