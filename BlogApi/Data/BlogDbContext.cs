using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogApi.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Blog> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        public BlogDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseNpgsql("Host=localhost;Port=5432;Database=QomeK;Username=postgres;Password=gangoptimus");
    }
}
