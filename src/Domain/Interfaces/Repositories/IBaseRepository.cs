using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : EntityBase 
    {
         public T GetById(int id);
         public IEnumerable<T> GetAll();
         public bool Create(T item);
         public bool Update(T item);
         public bool Delete(int id);
         public Task<T> GetByIdAsync(int id);
         public Task<IEnumerable<T>> GetAllAsync();
         public Task<bool> CreateAsync(T item);
         public Task<bool> UpdateAsync(T item);
         public Task<bool> DeleteAsync(int id);
    }
}