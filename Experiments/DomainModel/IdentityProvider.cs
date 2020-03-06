using System;

namespace DomainModel
{
    public class IdentityProvider : IIdentityProvider
    {
        public Guid CreateId()
        {
            return Guid.NewGuid();
        }
    }
}