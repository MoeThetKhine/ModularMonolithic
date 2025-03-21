using DotNet8.Architecture.Shared;

namespace DotNet8.Modules.Application.Features.Blog.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<BlogModel>>
{
	private readonly IBlogRepository _blogRepository;

	public CreateBlogCommandHandler(IBlogRepository blogRepository)
	{
		_blogRepository = blogRepository;
	}

	public async Task<Result<BlogModel>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		if(request.requestModel.BlogTitle.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Title cannot be empty.");
			goto result;
		}

		if (request.requestModel.BlogAuthor.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Author cannot be empty.");
			goto result;
		}

		if (request.requestModel.BlogContent.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Content cannot be empty.");
			goto result;
		}

		result = await _blogRepository.CreateBlogAsync(request.requestModel, cancellationToken);

	result:
		return result;
	}
}
