using System;

namespace DomainModel
{
    public interface ICustomer : ISnapshotable<ICustomer, CustomerSnapshot>
    {
        Guid Id { get; }
        string Name { get; }
        string Address { get; }
        void Rename(string newName);
        void ChangeAddress(string newAddress);
    }
}