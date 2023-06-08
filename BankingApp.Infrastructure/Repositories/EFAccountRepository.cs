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
    public class EFAccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;
        public EFAccountRepository(BankingDbContext context)
        {
            _context = context;
        }

        public void Create(Account entity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Account entity)
        {
            await _context.Accounts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingAccount = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(deletingAccount);
            await _context.SaveChangesAsync();
        }

        public IList<Account> GetAll()
        {
            return _context.Accounts.AsNoTracking().ToList();
        }

        public async Task<IList<Account>> GetAllAsync()
        {
            return await _context.Accounts.AsNoTracking().ToListAsync();
        }

        public Account GetById(int id)
        {
            return _context.Accounts.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Account entity)
        {
            _context.Accounts.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
