using BlogApi.Data;
using BlogApi.Interfaces;
using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Repos
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogDbContext context) : base(context) { }
        public async Task<List<Blog>> GetBlogs()
        {
            var dbContext = (BlogDbContext)context;
            var blogs = dbContext.Blogs.ToListAsync();
            return await blogs;
		}
		public async Task<Blog> UpdateBlog(int blogId, string header, string body)
        {
            var dbContext = (BlogDbContext)context;
            Blog oldBlog = new Blog();
           
            oldBlog =  dbContext.Blogs.Where(x=>x.Id == blogId).First();
            oldBlog.Header = header;
            oldBlog.Body= body;
            dbContext.Blogs.Update(oldBlog);
            await context.SaveChangesAsync();
            return oldBlog;
        }
        public async Task<Blog> AddComment(int blogId, string comment, string username)
        {
            var dbContext = (BlogDbContext)context;
            Blog notcommentedPost = new Blog();
            notcommentedPost = dbContext.Blogs.Where(x=>x.Id==blogId).First();
            CommentSpr commentSpr= new CommentSpr();
            commentSpr.Comment =comment;
            commentSpr.BlogId= blogId;
            commentSpr.Username= username;
            List<CommentSpr> comments = new List<CommentSpr>();
            comments.Add(commentSpr);
            notcommentedPost.CommentSpr = comments;
            dbContext.Blogs.Update(notcommentedPost);
            dbContext.CommentSprs.Add(commentSpr);
            await context.SaveChangesAsync();
            return notcommentedPost;
        }
        public async Task<string> DeleteBlog(int blogId, string username)
        {
            var dbContext = (BlogDbContext)context;
			Blog notdeletedPost = new Blog();
            List<CommentSpr> commentSpr= new List<CommentSpr>();
			notdeletedPost = dbContext.Blogs.Where(x => x.Id == blogId).First();
            commentSpr =await dbContext.CommentSprs.Where(x=>x.BlogId==blogId).ToListAsync();
            if (username != notdeletedPost.Author)
            {
                return "You not author";
            }
            dbContext.Remove(notdeletedPost);
            dbContext.RemoveRange(commentSpr);
            dbContext.SaveChanges();
            return "deleted!";
		}
     }
}
