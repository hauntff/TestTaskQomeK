using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(HabrDbContext context) : base(context) { }
        public async Task<List<Post>> GetPostsAsync()
        {
            var dbContext = (HabrDbContext)context;
            var posts = await dbContext.Posts.ToListAsync();
            return posts;
        }

    }
}
