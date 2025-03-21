using DotNet8.Architecture.DTOs.Feature.PageSetting;
using DotNet8.Architecture.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Modules.Infrastructure.Features.Blog;

public class BlogRepository : IBlogRepository
{
	private readonly AppDbContext _context;

	public BlogRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		Result<BlogListModelV1> result;

		try
		{
			var query = _context.TblBlogs.OrderByDescending(x => x.BlogId);
			var lst = await query
				.Paginate(pageNo, pageSize)
				.ToListAsync(cancellationToken: cancellationToken);
			var totalCount = await query.CountAsync(cancellationToken: cancellationToken);
			var pageCount = totalCount / pageSize;
			if(totalCount % pageSize > 0)
			{
				pageCount++;
			}

			var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
			var model = new BlogListModelV1()
			{
				DataLst = lst.Select(x => new BlogModel()
				{
					BlogId = x.BlogId,
					BlogTitle = x.BlogTitle,
					BlogAuthor = x.BlogAuthor,
					BlogContent = x.BlogContent,
				}).AsQueryable(),
				PageSetting = pageSettingModel
			};

			result = Result<BlogListModelV1>.Success(model);
		}

		catch (Exception ex)
		{
			result = Result<BlogListModelV1>.Failure(ex);
		}
		return result;
	}
}
