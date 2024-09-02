using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Queries;
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

        public User Authenticate(string nome, string password)
        {
            var user = _context.Users.AsNoTracking().Where(UserQueries.Authentication(nome,password)).FirstOrDefault();

            return user;
        }

        public bool Create(User item)
        {
            if (item == null)
                return false;

            _context.Users.Add(item);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CreateAsync(User item)
        {
            if (item == null)
                return false;

            await _context.Users.AddAsync(item);
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

            _context.Users.Remove(item);
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

            _context.Users.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            var result = _context.Users.Include(x => x.Posts).AsEnumerable();
            return result;
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            var result = _context.Users.AsNoTracking();
            return result as Task<IEnumerable<User>>;
        }

        public User GetById(int id)
        {
            var result = _context.Users.Where(UserQueries.GetById(id)).FirstOrDefault();
            return result;

        }

        public Task<User> GetByIdAsync(int id)
        {
            var result = _context.Users.Where(UserQueries.GetById(id)).FirstOrDefaultAsync();
            return result;
        }

        public bool Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateAsync(User item)
        {
            _context.Users.Update(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}