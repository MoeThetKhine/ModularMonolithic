using DotNet8.Architecture.DTOs.Feature.PageSetting;

namespace DotNet8.Architecture.DTOs.Feature.Blog;

public class BlogListModel
{
	public IEnumerable<BlogModel> DataLst { get; set; }
	public PageSettingModel PageSetting { get; set; }
}

public class BlogListModelV1
{
	public IQueryable<BlogModel> DataLst { get; set; }
	public PageSettingModel PageSetting { get; set; }
}
