using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Repositories
{
    public class FakeAccountRepository : IAccountRepository
    {
        private List<Account> accounts;

        public FakeAccountRepository()
        {
            accounts = new()
            {
                new() { Id = 1, Name = "Savings Account", Amount = 3450.12M, CustomerId = 1},
                new() { Id = 2, Name = "Cash Account", Amount = 1450.12M, CustomerId = 1},
                new() { Id = 3, Name = "Current Account", Amount = 2340.32M, CustomerId = 2},
                new() { Id = 4, Name = "Investment Account", Amount = 1250.72M, CustomerId = 3},
            };
        }

        public void Create(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Account> GetAll()
        {
            return accounts;
        }

        public Task<IList<Account>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Account GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
