using CustomerManagement.Interfaces;
using CustomerManagement.Models;
using CustomerManagement.Models.DTOs.Addresses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Implementations
{
    public class AddressServices : IAddressService
    {
        private readonly IAddressRepository addressRepository;
        public AddressServices(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task AddAddress(AddressDetailsModel address)
        {
            var newAddress = new Address
            {
                Id = address.Id,
                CustomerId = address.CustomerId,
                AdressName = address.AdressName,
                City = address.City,
                PostalCode = address.PostalCode,
            };
            await addressRepository.AddAddress(newAddress);
        }

        public async Task DeleteAddress(int addressId)
        {
            await addressRepository.DeleteAddress(addressId);
        }

        public async Task<AddressDetailsModel> GetAddress(int addressId)
        {
            Address address = await addressRepository.FindById(addressId);
            var getAddress = new AddressDetailsModel
            {
                Id = address.Id,
                CustomerId = address.CustomerId,
                AdressName = address.AdressName,
                City = address.City,
                PostalCode = address.PostalCode,
            };
            return getAddress;
        }

        //    public async Task<List<AddressDetailsModel>> GetAddresses(int customerId)
        //{
        //    List<Address> address = await addressRepository.FindAllAddresses(customerId);
        //    var result =  address.Select(x => new AddressDetailsModel
        //    {
        //        Id = x.Id,
        //        CustomerId = x.CustomerId,
        //        AdressName = x.AdressName,
        //        City = x.City,
        //        PostalCode = x.PostalCode,
        //    }).ToList();
        //    return result;
        //}

        public async Task UpdateAddress(AddressDetailsModel address)
        {
            var updatedAddress = new Address
            {
                Id = address.Id,
                CustomerId = address.CustomerId,
                AdressName = address.AdressName,
                City = address.City,
                PostalCode = address.PostalCode,
            };
            await addressRepository.UpdateAddress(updatedAddress);
        }
    }
}
