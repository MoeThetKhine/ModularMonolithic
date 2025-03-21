using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Modules.Domain.Features.Blog;


#region Tbl_Blog

public class Tbl_Blog
{
	[Key]
	public long BlogId { get; set; }

	public string BlogTitle { get; set; } = null!;

	public string BlogAuthor { get; set; } = null!;

	public string BlogContent { get; set; } = null!;

	public bool? DeleteFlag { get; set; }
}

#endregion
