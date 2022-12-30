using BlogApi.DTO;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Interfaces
{
	public interface IBlogService
	{
		Task<List<Blog>> GetBlogs();
		Task<ActionResult<Blog>> Add(BlogDto blog);
		Task<Blog> UpdateBlog(int blogId, string header, string body);
		Task<Blog> AddComment(int blogId, string comment, string username);
		Task<string> DeletePost(int blogId, string username);
	}
}
