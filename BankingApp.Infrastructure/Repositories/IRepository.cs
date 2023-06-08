using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T?> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
        IList<T> GetAll();
        T GetById(int id);
        Task CreateAsync(T entity);
        void Create(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);

    }
}
