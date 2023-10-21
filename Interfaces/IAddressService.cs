using CustomerManagement.Models.DTOs.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface IAddressService
    {
        //Task<List<AddressDetailsModel>> GetAddresses(int customerId);
        Task<AddressDetailsModel>GetAddress(int addressId);
        Task UpdateAddress(AddressDetailsModel address);
        Task AddAddress(AddressDetailsModel address);
        Task DeleteAddress(int addressId);
    }
}
