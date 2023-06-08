using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private List<Customer> customers;

        public FakeCustomerRepository()
        { 
            customers = new()
            {
                new() { Id = 1, Name = "Arda", Surname = "Kılıç", Age = 22, Location = "Üsküdar", UserId = 1},
                new() { Id = 2, Name = "Türkay", Surname = "Ürkmez", Age = 35, Location = "Eskişehir", UserId = 2},
                new() { Id = 3, Name = "Berfin Nur", Surname = "Uğur", Age = 22, Location = "Altunizade", UserId = 3},
            };
        }
        public Task CreateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAll()
        {
            return customers;
        }
        public Customer GetById(int id)
        {
            return customers.FirstOrDefault(customer => customer.Id == id);
        }

        public Task<IList<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer entity)        
        {
            throw new NotImplementedException();
        }

        public void Create(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
