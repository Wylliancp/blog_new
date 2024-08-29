using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class BlogContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
