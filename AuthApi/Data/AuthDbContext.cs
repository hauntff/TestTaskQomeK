using AuthApi.DTO;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Data
{
    public class AuthDbContext : DbContext
    {
        public DbSet<UserDto> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
        public AuthDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseNpgsql("Host=localhost;Port=5432;Database=QomeK;Username=postgres;Password=gangoptimus");
    }
}
