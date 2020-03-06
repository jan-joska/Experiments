using System;

namespace DomainModel
{
    public class OrderFactory
    {
        private readonly IIdentityProvider _identityProvider;

        public OrderFactory(IIdentityProvider identityProvider)
        {
            _identityProvider = identityProvider;
        }

        public IOrder Create()
        {
            return new Order(_identityProvider.CreateId());
        }

        public IOrder Create(Guid id)
        {
            return new Order(id);
        }

    }
}