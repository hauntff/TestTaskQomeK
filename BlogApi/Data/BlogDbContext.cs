using AuthApi.DTO;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogApi.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<CommentSpr> CommentSprs { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        public BlogDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseNpgsql("Host=localhost;Port=5432;Database=QomeK;Username=postgres;Password=gangoptimus");
    }
}
