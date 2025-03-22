namespace DotNet8.Modules.Application.Features.Blog.DeleteBlog;

#region DeleteBlogCommand

public class DeleteBlogCommand : IRequest<Result<BlogModel>>
{
	public int BlogId {  get; set; }	

	public DeleteBlogCommand(int blogId)
	{
		BlogId = blogId;
	}
}

#endregion