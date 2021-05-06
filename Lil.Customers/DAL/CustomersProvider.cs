using Lil.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Customers.DAL
{
    public class CustomersProvider : ICustomersProvider
    {
        private List<Customer> repo = new List<Customer>();
        public CustomersProvider()
        {
            repo.Add(new Customer()
            {
                Id = "1",
                Name = "Rodrigo",
                City = "Ciudad de México"
            });

            repo.Add(new Customer()
            {
                Id = "2",
                Name = "Renata",
                City = "Medellín"
            });

            repo.Add(new Customer()
            {
                Id = "3",
                Name = "Carlos",
                City = "Pereira"
            });

            repo.Add(new Customer()
            {
                Id = "4",
                Name = "Llorente",
                City = "Madrid"
            });
        }
        public Task<Customer> GetAsync(string id)
        {
            var customer = repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(customer);
        }
    }
}
