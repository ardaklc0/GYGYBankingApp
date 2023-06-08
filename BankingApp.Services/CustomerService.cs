using Azure.Core;
using BankingApp.DataTransferObject.Requests;
using BankingApp.DataTransferObject.Responses.Customer;
using BankingApp.Entities;
using BankingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;
        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CustomerDisplayResponse>> GetCustomerDisplayResponse()
        {
            var customers = await repository.GetAllAsync();
            var responses = customers.Select(customer => new CustomerDisplayResponse 
            {
                Id = customer.Id,
                Age = customer.Age,
                CreationDate = customer.CreationDate,
                Location = customer.Location,
                Name = customer.Name,
                Surname = customer.Surname,
                UserId = customer.UserId
            });
            return responses;

        }

        public async Task<CustomerDisplayResponse> GetCustomerAsync(int id)
        {
            var customer = await repository.GetByIdAsync(id);
            var response = new CustomerDisplayResponse
            {
                Id = customer.Id,
                Age = customer.Age,
                CreationDate = customer.CreationDate,
                Location = customer.Location,
                Name = customer.Name,
                Surname = customer.Surname,
                UserId = customer.UserId
            };
            return response;
        }

        public async Task<CustomerDisplayResponse> GetCustomerWithRespectToUser(int userId)
        {
            var customerRequest = await repository.GetAllAsync();
            var customer = customerRequest.FirstOrDefault(customer => customer.UserId == userId);
            var response = new CustomerDisplayResponse
            {
                Id = customer.Id,
                Age = customer.Age,
                CreationDate = customer.CreationDate,
                Location = customer.Location,
                Name = customer.Name,
                Surname = customer.Surname,
                UserId = customer.UserId
            };
            return response;
        }

        public async Task CreateCustomerAsync(CreateNewCustomerRequest request)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Surname = request.Surname,
                Age = request.Age,
                Location = request.Location,
                UserId = request.UserId
            };
            await repository.CreateAsync(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task UpdateCustomer(UpdateCustomerRequest entity)
        {
            var updatedCustomer = new Customer
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Age = entity.Age,
                Location = entity.Location,
                UserId = entity.UserId
            };
            await repository.UpdateAsync(updatedCustomer);
        }

        public async Task<int> GetCustomerIdWithRespectToUser(int userId)
        {
            var customer = await repository.GetAllAsync();
            var response = customer.FirstOrDefault(customer => customer.UserId == userId).Id;
            return response;
        }
    }
}
