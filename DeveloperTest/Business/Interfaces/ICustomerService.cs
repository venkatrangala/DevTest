using DeveloperTest.Models;

namespace DeveloperTest.Business.Interfaces
{
   public interface ICustomerService
    {
        CustomerModel[] GetCustomers();

        CustomerModel GetCustomerById(int customerId);

        CustomerModel CreateCustomer(BaseCustomerModel model);
    }
}
