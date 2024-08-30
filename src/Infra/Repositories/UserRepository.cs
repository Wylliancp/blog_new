using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogOneContext _context;

        public UserRepository(BlogOneContext context)
        {
            _context = context;
        }

        public bool Create(User item)
        {
            if (item == null)
                return false;

            _context.Add(item);//especificar o dbset
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CreateAsync(User item)
        {
            if (item == null)
                return false;

            await _context.AddAsync(item);//especificar o dbset
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0 || id == default)
                return false;

            var item = _context.Users.Where(x => x.Id == id)
                                     .AsNoTracking()
                                     .FirstOrDefault();

            if (item == null)
                return false;

            _context.Remove(item);//especificar o dbset
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0 || id == default)
                return false;

            var item = await _context.Users.Where(x => x.Id == id)
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync();

            if (item == null)
                return false;

            _context.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            var result = _context.Users.Include(x => x.Posts).AsEnumerable();
            return result as IEnumerable<User>;
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            var result = _context.Users.AsNoTracking();
            return result as Task<IEnumerable<User>>;
        }

        public User GetById(int id)
        {
            var result = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            return result as User;
        }

        public Task<User> GetByIdAsync(int id)
        {
            var result = _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result as Task<User>;
        }

        public bool Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateAsync(User item)
        {
            _context.Users.Update(item as User);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}