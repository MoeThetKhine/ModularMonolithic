using DotNet8.Architecture.DTOs.Feature.Blog;
using DotNet8.Architecture.Utils;
using DotNet8.Architecture.Utils.Resources;
using DotNet8.Modules.Domain.Features.Blog;
using MediatR;

namespace DotNet8.Modules.Application.Features.Blog.GetBlogList;

public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<BlogListModelV1>>
{
	private readonly IBlogRepository _blogRepository;

	public GetBlogListQueryHandler(IBlogRepository blogRepository)
	{
		_blogRepository = blogRepository;
	}

	public async Task<Result<BlogListModelV1>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
	{
		Result<BlogListModelV1> result;

		if(request.PageNo <= 0)
		{
			result = Result<BlogListModelV1>.Fail(MessageResource.InvalidPageNo);
			goto result;
		}

		if (request.PageSize <= 0)
		{
			result = Result<BlogListModelV1>.Fail(MessageResource.InvalidPageSize);
			goto result;
		}

		result = await _blogRepository.GetBlogsAsync(request.PageNo, request.PageSize, cancellationToken);

	result:
		return result;
	}
}
