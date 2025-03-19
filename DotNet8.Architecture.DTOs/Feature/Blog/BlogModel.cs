using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architecture.DTOs.Feature.Blog
{
	public class BlogModel
	{
		public long BlogId { get; set; }

		public string BlogTitle { get; set; } = null!;

		public string BlogAuthor { get; set; } = null!;

		public string BlogContent { get; set; } = null!;

		public bool? DeleteFlag { get; set; }
	}
}
