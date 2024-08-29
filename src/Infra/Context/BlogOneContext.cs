using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Context
{
    public class BlogOneContext : DbContext
    {

        public BlogOneContext(DbContextOptions<BlogOneContext> options) : base(options)
        {

        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Posts>()
                .ToTable("Post");
            

            modelBuilder.Entity<Posts>().Property(x => x.Id);
            
            modelBuilder.Entity<Posts>().Property(x => x.UserId)
            .HasColumnName("UserId");


            modelBuilder.Entity<Posts>()
                .Property(x => x.Title)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");

            modelBuilder.Entity<Posts>()
                .Property(x => x.Description)
                .HasMaxLength(160)
                .HasColumnType("varchar(960)");


            modelBuilder.Entity<Posts>().Property(x => x.DateCreate);

            modelBuilder.Entity<Posts>().HasIndex(x => x.DateEnd);



            modelBuilder.Entity<User>()
                .ToTable("User");


            modelBuilder.Entity<User>().Property(x => x.Id);


            modelBuilder.Entity<User>()
                .Property(x => x.Nome)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .HasMaxLength(160)
                .HasColumnType("varchar(60)");


            modelBuilder.Entity<User>().Property(x => x.DateCreate);

            modelBuilder.Entity<User>().HasIndex(x => x.DateEnd);
        }

    }
}
