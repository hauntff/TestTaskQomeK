using BlogApi.DTO;
using BlogApi.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Services
{
    public class BlogService : IBlogService
	{
		private readonly Blog blog = new Blog();
		private readonly IBlogRepository _blogRepository;
		public BlogService(IBlogRepository blogRepository)
		{
			_blogRepository= blogRepository;
		}
		public async Task<List<Blog>> GetBlogs()
		{
			return await _blogRepository.GetBlogs();
		}
		public async Task<ActionResult<Blog>> Add(BlogDto blogg)
		{
			blog.Author = blogg.Author;
			blog.Body = blogg.Body;
			blog.Header = blogg.Header;
			_blogRepository.Insert(blog);
			return blog;
		}
		public async Task<Blog> UpdateBlog(int blogId, string header, string body)
		{
			var updatedBlog  = _blogRepository.UpdateBlog(blogId, header, body);
			return await updatedBlog;
		}
		public async Task<Blog> AddComment(int blogId, string comment, string username)
		{
			var commentedBlog = _blogRepository.AddComment(blogId, comment, username);
			return await commentedBlog;
		}
		public async Task<string> DeletePost(int blogId, string username)
		{
			var deletedPost = _blogRepository.DeleteBlog(blogId, username);
			return await deletedPost;
		}
	}
}
