using DotNet8.Architecture.DTOs.Feature.Blog;
using DotNet8.Architecture.Utils;

namespace DotNet8.Modules.Domain.Features.Blog;

public interface IBlogRepository
{
	Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken);
}
