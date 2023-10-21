using CustomerManagement.Data;
using CustomerManagement.Interfaces;
using CustomerManagement.Migrations;
using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext context;

        public AddressRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAddress(Address address)
        {
            context.Add(address);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAddress(int id)
        {
            Address address = context.Addresses.Where(x => x.CustomerId == id).FirstOrDefault();
            context.Addresses.Remove(address);
            await context.SaveChangesAsync();
        }

        public async Task<List<Address>> FindAllAddresses(int customerId)
        {
            List<Address> addresses = await context.Addresses.Where(x => x.CustomerId == customerId).ToListAsync();
            return addresses;
        }

        public async Task<Address> FindById(int id)
        {
            var address = await context.Addresses.Where(x => x.Id == id).FirstOrDefaultAsync();
            return address;
        }

        public async Task UpdateAddress(Address address)
        {
            context.Addresses.Update(address);
            await context.SaveChangesAsync();
        }
    }
}
