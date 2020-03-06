using System;

namespace DomainModel
{
    public interface IIdentityProvider
    {
        Guid CreateId();
    }
}