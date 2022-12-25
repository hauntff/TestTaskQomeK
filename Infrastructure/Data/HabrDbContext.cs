using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HabrDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public HabrDbContext(DbContextOptions<HabrDbContext> options) : base(options) { }
        public HabrDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=KatanaStoreProduct;Username=postgres;Password=gangoptimus");
    }
}
