using DotNet8.Architecture.DTOs.Feature.PageSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architecture.DTOs.Feature.Blog
{
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
}
