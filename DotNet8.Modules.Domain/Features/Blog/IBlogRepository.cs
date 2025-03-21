namespace DotNet8.Modules.Domain.Features.Blog;

public interface IBlogRepository
{
	Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken);

	Task<Result<BlogModel>> GetBlogByIdAsync(int id, CancellationToken cancellationToken);
}
