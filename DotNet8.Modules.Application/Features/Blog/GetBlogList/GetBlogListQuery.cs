﻿namespace DotNet8.Modules.Application.Features.Blog.GetBlogList;

public class GetBlogListQuery : IRequest<Result<BlogListModelV1>>
{
	public int PageNo {  get; set; }
	public int PageSize { get; set; }

	public GetBlogListQuery(int pageNo, int pageSize)
	{
		PageNo = pageNo;
		PageSize = pageSize;
	}	
}
