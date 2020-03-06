namespace DomainModel
{
    public interface IOrderConversionService
    {
        IOrder ConvertToAnotherCurrency(IOrder order, string currencyCode);
    }
}