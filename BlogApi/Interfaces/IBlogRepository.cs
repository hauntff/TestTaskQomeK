using Domain.Entity;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Interfaces
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
		Task<List<Blog>> GetBlogs();
		Task<Blog> UpdateBlog(int blogId, string header, string body);

		Task<Blog> AddComment(int blogId, string comment, string username);
	    Task<string> DeleteBlog(int blogId, string username);
	}
}
