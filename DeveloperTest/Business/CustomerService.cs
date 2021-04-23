using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public CustomerModel[] GetCustomers()
        {
            return _context.Customers.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Type = x.Type
            }).ToArray();
        }

        public CustomerModel GetCustomerById(int CustomerId)
        {
            return _context.Customers.Where(x => x.CustomerId == CustomerId)
                                     .Select(x => new CustomerModel
                                     {
                                         CustomerId = x.CustomerId,
                                         Name = x.Name,
                                         Type = x.Type
                                     }).SingleOrDefault();
        }

        public CustomerModel CreateCustomer(BaseCustomerModel model)
        {
            var addedCustomer = _context.Customers.Add(new Customer
            {
                Name = model.Name,
                Type = model.Type
            });

            _context.SaveChanges();

            return new CustomerModel
            {
                CustomerId = addedCustomer.Entity.CustomerId,
                Name = addedCustomer.Entity.Name,
                Type = addedCustomer.Entity.Type
            };
        }
    }
}
