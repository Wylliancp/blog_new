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
    public class PostsRepository : IPostsRepository
    {
        private readonly BlogOneContext _context;

        public PostsRepository(BlogOneContext context) 
        {
            _context = context;
        }

        public bool Create(Posts item)
        {
            if (item == null)
                return false;

            _context.Posts.Add(item);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CreateAsync(Posts item)
        {
            if (item == null)
                return false;

            await _context.Posts.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0 || id == default)
                return false;

            var item = _context.Posts.Where(x => x.Id == id)
                                     .AsNoTracking()
                                     .FirstOrDefault();

            if (item == null)
                return false;

            _context.Posts.Remove(item);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0 || id == default)
                return false;

            var item = await _context.Posts.Where(x => x.Id == id)
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync();

            if (item == null)
                return false;

            _context.Posts.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Posts> GetAll()
        {
            var result = _context.Posts.AsEnumerable();
            return result;
        }

        public Task<IEnumerable<Posts>> GetAllAsync()
        {
            var result = _context.Posts.AsNoTracking();
            return result as Task<IEnumerable<Posts>>;
        }

        public Posts GetById(int id)
        {
            var result = _context.Posts.Where(PostsQueries.GetById(id)).FirstOrDefault();
            return result;
        }

        public Task<Posts> GetByIdAsync(int id)
        {
            var result = _context.Posts.Where(PostsQueries.GetById(id)).FirstOrDefaultAsync();
            return result; 
        }

        public bool Update(Posts item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateAsync(Posts item)
        {
            _context.Posts.Update(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}