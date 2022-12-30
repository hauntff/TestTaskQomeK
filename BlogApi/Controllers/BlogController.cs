using BlogApi.DTO;
using BlogApi.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
		private readonly IBlogService _blogService;
		public BlogController(IBlogService blogService)
		{
			_blogService = blogService;
		}
		[HttpGet("getAllPost")]
		public async Task<List<Blog>> GetBlogsAsync()
		{
			return await _blogService.GetBlogs();
		}
		[HttpPost("add")]
		public async Task<IActionResult> AddPost(BlogDto blog)
		{
			try
			{
				await _blogService.Add(blog);
				return Ok(blog);
			}
			catch (Exception)
			{
				return BadRequest("Error");
			}
		}
		[HttpPost("update")]
		public async Task<Blog> UpdateBlog(int blogId, string header, string body)
		{
			
			return await _blogService.UpdateBlog(blogId, header, body);
		}
		[HttpPost("comment")]
		public async Task<Blog> Comment(int blogId, string comment, string username)
		{
			return await _blogService.AddComment(blogId, comment, username);
		}
		[HttpPost("delete")]
		public async Task<string> DeletePost(int blogId, string username)
		{
			return await _blogService.DeletePost(blogId, username);
		}
	}
}
