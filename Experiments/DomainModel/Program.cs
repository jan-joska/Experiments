using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace DomainModel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var customerRepository = new CustomerRepository();
                var orderFactory = new OrderFactory(new IdentityProvider());
                var orderRepository = new OrderRepository();
                DomainEvents.Register(new Action<CustomerRenamed>(cr =>
                {
                    var order = orderFactory.Create(Guid.NewGuid());
                    order.AttachToCustomer(cr.Id);
                    order.AddItem(new Item(new ArticleNumber("PRESENT","0001"), 1));
                    orderRepository.Save(order);                    
                }));
                var customer = new Customer(Guid.NewGuid(), "Jan Libersky");
                customer.ChangeAddress("Prvni ulice 25");
                var id = customer.Id;
                customerRepository.Save(customer);
                var c2 = customerRepository.GetById(id);
                c2.Rename("New Name");
                customerRepository.Save(c2);
            }
            finally
            {
                DomainEvents.ClearCallbacks();
            }

            

            


            //try
            //{
            //    try
            //    {
            //        DomainEvents.Register(new Action<OrderSumCalculated>(osc =>
            //        {
            //            Console.WriteLine($"A total was calculated on order {osc.OrderId}. It was {osc.Total}");
            //        }));

            //        var f = new OrderFactory(new IdentityProvider());
            //        IOrderRepository rep = new OrderRepository();
            //        IOrder o3 = rep.Get(Guid.NewGuid());

            //        if (o3.CanAddDangerousItem)
            //        {
            //            o3.AddItem(new Item(new ArticleNumber("EX", "1234"), 5));
            //            rep.Save(o3);
            //        }
            //        else
            //        {
            //            var o4 = f.Create();
            //            o4.AddItem(new Item(new ArticleNumber("EX", "1234"), 5));
            //            rep.Save(o4);
            //        }

            //        rep.Save(o3);
            //        var ocs = new OrderConversionService(f, new ExchangeRateService());
            //        var o = f.Create();
            //        o.AddItem(new Item(new ArticleNumber("EX", "0001"), 1));
            //        o.AddItem(new Item(new ArticleNumber("BX", "0654"), 1));
            //        foreach (var i in o.GetItems())
            //        {
            //            Console.WriteLine(i);
            //        }
            //        Console.Write($"Total: {o.GetTotal()}");

            //        var o2 = ocs.ConvertToAnotherCurrency(o, "CZK");
            //        foreach (var i in o2.GetItems())
            //        {
            //            Console.WriteLine(i);
            //        }
            //    }
            //    finally
            //    {
            //        DomainEvents.ClearCallbacks();    
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            Console.ReadLine();
        }
    }
}

