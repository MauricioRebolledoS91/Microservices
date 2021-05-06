using Lil.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Sales.DAL
{
    //la intención de esta clase, es que sea la que se conecte a la bdd, pero
    //lo haremos en memoria sobre esto
    public class SalesProvider : ISalesProvider
    {
        private readonly List<Order> repo = new List<Order>(); 
        public SalesProvider()
        {
            repo.Add(new Order()
            {
                Id = "0001",
                CustomerId = "1",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem()
                    { OrderId = "0001",
                      Id = 1,
                      Price = 50,
                      ProductId = "23",
                      Quantity = 2
                    }
                }
            });
        }
        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = repo.Where(c => c.CustomerId == customerId).ToList();
            return Task.FromResult((ICollection<Order>)orders);
        }
    }
}
