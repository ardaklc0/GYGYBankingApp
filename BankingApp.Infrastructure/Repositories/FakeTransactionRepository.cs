using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Repositories
{
    public class FakeTransactionRepository : ITransactionRepository
    {
        private List<Transaction> transactions;

        public FakeTransactionRepository()
        {
            transactions = new()
            {
                new() {Id = 1, CustomerId = 1, Name = "Grocery Shopping", Amount = 123.42M, Description = "Transaction completed succesfully", AccountId = 1},
                new() {Id = 2, CustomerId = 1, Name = "Gas Shopping", Amount = 249.99M, Description = "Transaction completed succesfully", AccountId = 2},
                new() {Id = 3, CustomerId = 3, Name = "Lego Shopping", Amount = 459.95M, Description = "Transaction completed succesfully", AccountId = 3},
                new() {Id = 4, CustomerId = 3, Name = "Lego Shopping", Amount = 459.95M, Description = "Transaction completed succesfully", AccountId = 4},
            }; 
        }

        public void Create(Transaction entity)
        {
            transactions.Add(entity);
        }

        public Task CreateAsync(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Transaction> GetAll()
        {
            return transactions;
        }

        public Task<IList<Transaction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Transaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
