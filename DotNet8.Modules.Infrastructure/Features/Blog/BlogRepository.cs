global using DotNet8.Architecture.DbService.AppDbContextModels;
global using DotNet8.Architecture.DTOs.Feature.Blog;
global using DotNet8.Architecture.Utils;
global using DotNet8.Modules.Domain.Features.Blog;

namespace DotNet8.Modules.Infrastructure.Features.Blog;

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
