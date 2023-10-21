using CustomerManagement.Interfaces;
using CustomerManagement.Models;
using CustomerManagement.Models.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Implementations
{
    public class CustomerService : ICustomerService
    { 
       private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task AddCustomer(CustomerAddModel model, string userId)
        {
            if (model.Surname == null || model.Name == null)
            {
                throw new ArgumentNullException("Name or Surname");
            }

            var customer = new Customer()
            {
                UserId = userId,
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                Age = model.Age,
                Sex = model.Sex
            };

            await customerRepository.Add(customer);
        }

        public async Task DeleteCustomer(int customerId, string userId)
        {
            var customer = customerRepository.FindById(customerId);
            if(customer == null)
            {
                throw new Exception("Customer Not Found");
            }
            await customerRepository.Delete(customerId);
        }

        public async Task<CustomerDetailsModel> GetCustomer(int customerId, string userId)
        {
            var customer = await customerRepository.FindById(customerId);
            if (customer == null)
            {
                throw new Exception("Customer Not Found");
            }

            var ListedCustomer = new CustomerDetailsModel
            {
                UserId = customer.UserId,
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber,
                Age = customer.Age,
                Sex = customer.Sex,
                Addresses=customer.Addresses.Select(x => new CustomerAddressDetails
                {
                    Id = x.Id,
                    City = x.City,
                    AdressName = x.AdressName,
                    PostalCode = x.PostalCode
                }).ToList()
            };
            return ListedCustomer;
        }

        public async Task<List<CustomerListModel>> GetCustomers(string userId)
        {
            var customers = await customerRepository.FindAllByUserId(userId);

            var customerList = customers.Select(x => new CustomerListModel
            {
                UserId = x.UserId,
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
                Age = x.Age,
                Sex = x.Sex
            }).ToList();
            return customerList;
        }

        public async Task UpdateCustomer(CustomerUpdateModel model)
        {
            var UpdatedCustomer = new Customer
            {
                UserId = model.UserId,
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                Age = model.Age,
                Sex = model.Sex
            };
            await customerRepository.Update(UpdatedCustomer);
        }
    }
}
