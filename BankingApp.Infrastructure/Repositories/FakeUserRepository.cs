using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private List<User> users;

        public FakeUserRepository()
        {
            users = new()
            {
                new() {Id = 1, Email = "ardaklc0@gmail.com", Password = "12345", Role = "Admin", UserName = "ardaklc", Name = "Arda" },
                new() {Id = 2, Email = "turkayurk0@gmail.com", Password = "12345", Role = "Client", UserName = "turkyurkmz", Name = "Türkay"},
                new() {Id = 3, Email = "berfinnur0@gmail.com", Password = "12345", Role = "Client", UserName = "berfnnur", Name = "Berfin" }
            };
                
        }

        public Task CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public IList<User> GetAll()
        {
            return users;
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
