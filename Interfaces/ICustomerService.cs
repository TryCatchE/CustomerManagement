using CustomerManagement.Models;
using CustomerManagement.Models.DTOs.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDetailsModel> GetCustomer(int customerId, string userId);
        Task<List<CustomerListModel>> GetCustomers(string userId);
        Task AddCustomer(CustomerAddModel model, string userId);
        Task UpdateCustomer(CustomerUpdateModel model);
        Task DeleteCustomer(int customerId, string userId);

    }
}
