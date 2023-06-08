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
    public class EFUserRepository : IUserRepository
    {
        private readonly BankingDbContext _context;
        public EFUserRepository(BankingDbContext context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingUser = await _context.Users.FindAsync(id);
            if (deletingUser != null)
            {
                _context.Users.Remove(deletingUser);
                await _context.SaveChangesAsync();
            }
        }

        public IList<User> GetAll()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
