namespace DotNet8.Modules.Infrastructure.Features.Blog;

public class BlogRepository : IBlogRepository
{
	private readonly AppDbContext _context;

	public BlogRepository(AppDbContext context)
	{
		_context = context;
	}

	#region GetBlogsAsync

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

	#endregion

	#region GetBlogByIdAsync

	public async Task<Result<BlogModel>> GetBlogByIdAsync(int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			var blog = await _context.TblBlogs.FindAsync([id,cancellationToken],cancellationToken  : cancellationToken);

			if(blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}

			result = Result<BlogModel>.Success(new BlogModel()
			{
				BlogId = blog.BlogId,
				BlogTitle = blog.BlogTitle,
				BlogAuthor = blog.BlogAuthor,
				BlogContent = blog.BlogContent,
			});
		}

		catch(Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);	
		}

	result:
		return result;
	}

	#endregion

	#region CreateBlogAsync

	public async Task<Result<BlogModel>> CreateBlogAsync(BlogRequestModel blogRequestModel, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			await _context.TblBlogs.AddAsync(blogRequestModel.ToEntity(), cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);

			result = Result<BlogModel>.Success();
		}

		catch (Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

		return result;
	}

	#endregion

	#region UpdateBlogAsync

	public async Task<Result<BlogModel>> UpdateBlogAsync(BlogRequestModel blogRequest, int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			var blog = await _context.TblBlogs.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

			if(blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}

			blog.BlogTitle = blogRequest.BlogTitle;
			blog.BlogAuthor = blogRequest.BlogAuthor;
			blog.BlogContent = blogRequest.BlogContent;

			_context.TblBlogs.Update(blog);
			await _context.SaveChangesAsync(cancellationToken);

			result = Result<BlogModel>.UpdateSuccess();
		}
		catch (Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

		result:
		return result;
	}

	#endregion

}
