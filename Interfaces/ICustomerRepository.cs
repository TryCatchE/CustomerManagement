using CustomerManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> FindAllByUserId(string userId);
        Task<Customer> FindById(int customerId);
        Task Add(Customer customer);
        Task Update(Customer customer);
        Task Delete(int id);
    }
}
