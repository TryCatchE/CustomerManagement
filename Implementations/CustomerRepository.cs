using CustomerManagement.Data;
using CustomerManagement.Interfaces;
using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Customer customer)
        {
            context.Add(customer);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Customer customer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }

        public async Task<List<Customer>> FindAllByUserId(string userId)
        {
            List<Customer> customers = await context.Customers.Where(x => x.UserId == userId).ToListAsync();
            return customers;
        }

        public async Task<Customer> FindById(int customerId)
        {
            Customer customer = await context.Customers.Include(x =>x.Addresses).Where(x => x.Id == customerId).FirstOrDefaultAsync();
            return customer;
        }

        public async Task Update(Customer customer)
        {
            context.Customers.Update(customer);
            await context.SaveChangesAsync();
        }
    }
}
