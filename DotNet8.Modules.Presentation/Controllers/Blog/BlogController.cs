﻿namespace DotNet8.Modules.Presentation.Controllers.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
	private readonly IMediator _mediator;

	public BlogController(IMediator mediator)
	{
		_mediator = mediator;
	}

	#region GetBlogsAsync

	[HttpGet]
	public async Task<IActionResult> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		var query = new GetBlogListQuery(pageNo, pageSize);
		var result = await _mediator.Send(query,cancellationToken);

		return Content(result);
	}

	#endregion

}
