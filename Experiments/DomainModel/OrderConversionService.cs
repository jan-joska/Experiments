namespace DomainModel
{
    public class OrderConversionService : IOrderConversionService
    {
        private readonly OrderFactory _factory;
        private readonly IExchangeRateService _exchangeRateService;

        public OrderConversionService(OrderFactory factory, IExchangeRateService exchangeRateService)
        {
            _factory = factory;
            _exchangeRateService = exchangeRateService;
        }

        public IOrder ConvertToAnotherCurrency(IOrder order, string currencyCode)
        {
            var newOrder = _factory.Create();
            foreach (var item in order.GetItems())
            {
                var newItem = new Item(item.Article, item.Count * (int)_exchangeRateService.GetRate("CZK"));
                newOrder.AddItem(newItem);
            }
            return newOrder;
        }
    }
}