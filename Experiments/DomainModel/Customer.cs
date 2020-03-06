using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace DomainModel
{

    public class CustomerRenamed : IDomainEvent
    {
        public Guid Id { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
    }

    public class CustomerRepository
    {
        private List<CustomerSnapshot> snapshots = new List<CustomerSnapshot>();

        public void Save(ICustomer customer)
        {
            var s = customer.CreateSnapshot();
            snapshots.Remove(snapshots.SingleOrDefault(i => i.Id == s.Id));
            snapshots.Add(s);
        }

        public ICustomer GetById(Guid id)
        {
            var s = snapshots.SingleOrDefault(i => i.Id == id);
            if (s == null)
            {
                return null;
            }
            Customer c = new Customer(s.Id, s.Name);
            return c.RehydrateFromSnapshot(s);
        }

    }

    public class Customer : ICustomer 
    {
        private string _name;

        public Customer(Guid id, string name)
        {
            Id = id;
            _name = name;
        }

        public Guid Id { get; }

        public string Name { get; }

        public void Rename(string newName)
        {
            var oldName = _name;
            _name = newName;
            DomainEvents.Raise(new CustomerRenamed() { OldName = oldName, NewName = newName, Id = Id});
        }

        public string Address { get; private set; }

        public void ChangeAddress(string newAddress)
        {
            Address = newAddress;
        }

        public CustomerSnapshot CreateSnapshot()
        {
            return new CustomerSnapshot {Address = Address, Id = Id, Name = _name};
        }

        public ICustomer RehydrateFromSnapshot(CustomerSnapshot snapshot)
        {
            var result = new Customer(snapshot.Id, snapshot.Name) {Address = snapshot.Address, _name = snapshot.Name};
            return result;
        }
    }
}