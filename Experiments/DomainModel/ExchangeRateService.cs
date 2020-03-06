namespace DomainModel
{
    public class ExchangeRateService : IExchangeRateService
    {
        public decimal GetRate(string currencyCode)
        {
            return 5;
        }
    }
}