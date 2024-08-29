using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
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

        public Posts GetPostsPeriodAsync(DateTime dateInitial, DateTime DateEnd)
        {
            return _context.Posts.Where(x => x.DateCreate == dateInitial && x.DateEnd == DateEnd).FirstOrDefault();
            
        }

        public bool Create(Posts item)
        {
            if (item == null)
                return false;

            _context.Add(item);//especificar o dbset
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CreateAsync(Posts item)
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

            var item = _context.Posts.Where(x => x.Id == id)
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

            var item = await _context.Posts.Where(x => x.Id == id)
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync();

            if (item == null)
                return false;

            _context.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Posts> GetAll()
        {
            var result = _context.Posts.AsEnumerable();
            return result as IEnumerable<Posts>;
        }

        public Task<IEnumerable<Posts>> GetAllAsync()
        {
            var result = _context.Posts.AsNoTracking();
            return result as Task<IEnumerable<Posts>>;
        }

        public Posts GetById(int id)
        {
            var result = _context.Posts.Where(x => x.Id == id).FirstOrDefault();
            return result as Posts;
        }

        public Task<Posts> GetByIdAsync(int id)
        {
            var result = _context.Posts.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result as Task<Posts>;
        }

        public bool Update(Posts item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateAsync(Posts item)
        {
            _context.Posts.Update(item as Posts);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}