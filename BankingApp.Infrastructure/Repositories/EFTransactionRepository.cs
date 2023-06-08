using BankingApp.Entities;
using BankingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Repositories
{
    public class EFTransactionRepository : ITransactionRepository
    {
        private readonly BankingDbContext _context;
        public EFTransactionRepository(BankingDbContext context)
        {
            _context = context;
        }

        public void Create(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Transaction entity)
        {
            await _context.Transactions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingTransaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(deletingTransaction);
            await _context.SaveChangesAsync();
        }

        public IList<Transaction> GetAll()
        {
            return _context.Transactions.AsNoTracking().ToList();
        }

        public async Task<IList<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.AsNoTracking().ToListAsync();
        }

        public Transaction GetById(int id)
        {
            return _context.Transactions.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Transaction entity)
        {
            _context.Transactions.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
