namespace DomainModel
{
    public interface IExchangeRateService
    {
        decimal GetRate(string currencyCode);
    }
}