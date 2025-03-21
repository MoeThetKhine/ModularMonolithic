using DotNet8.Architecture.DbService.AppDbContextModels;
using DotNet8.Architecture.DTOs.Feature.Blog;
using DotNet8.Architecture.Utils;
using DotNet8.Modules.Domain.Features.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Modules.Infrastructure.Features.Blog
{
	public class BlogRepository : IBlogRepository
	{
		private readonly AppDbContext _context;

		public BlogRepository(AppDbContext context)
		{
			_context = context;
		}

		public Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
