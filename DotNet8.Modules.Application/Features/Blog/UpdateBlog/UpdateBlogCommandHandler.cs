using DotNet8.Architecture.Shared;

namespace DotNet8.Modules.Application.Features.Blog.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result<BlogModel>>
{
	private readonly IBlogRepository _blogRepository;

	public UpdateBlogCommandHandler(IBlogRepository blogRepository)
	{
		_blogRepository = blogRepository;
	}

	public async Task<Result<BlogModel>> Handle(UpdateBlogCommand request,CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		if(request.RequestModel.BlogTitle.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Title cannot be empty.");
			goto result;
		}

		if (request.RequestModel.BlogAuthor.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Author cannot be empty.");
			goto result;
		}

		if (request.RequestModel.BlogContent.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Content cannot be empty.");
			goto result;
		}

		result = await _blogRepository.UpdateBlogAsync(request.RequestModel, request.BlogId, cancellationToken);

	result:
		return result;
	}
}
