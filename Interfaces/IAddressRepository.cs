using CustomerManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> FindAllAddresses(int customerId);
        Task<Address> FindById(int id);
        Task AddAddress (Address address);
        Task UpdateAddress(Address address);
        Task DeleteAddress(int id);

    }
}
