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
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly BankingDbContext _context;
        public EFCustomerRepository(BankingDbContext context)
        {
            _context = context;
        }

        public void Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingCustomer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(deletingCustomer);
            await _context.SaveChangesAsync();
        }

        public IList<Customer> GetAll()
        {
            return _context.Customers.AsNoTracking().ToList();
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Customer entity)
        {
            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
