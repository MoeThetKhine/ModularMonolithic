using DotNet8.Architecture.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architecture.Utils
{
	public class Result<T>
	{
		public T Data { get; set; }
		public string Message {  get; set; }
		public bool IsSuccess {  get; set; }
		public EnumStatusCode StatusCode { get; set; }
	}
}
