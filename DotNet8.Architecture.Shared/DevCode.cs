using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architecture.Shared
{
	public static class DevCode
	{
		public static string ToJson(this object obj)=>
			JsonConvert.SerializeObject(obj, Formatting.Indented);

		public static T ToObject<T>(this string jsonStr) => JsonConvert.DeserializeObject<T>(jsonStr)!;

		public static bool IsNullOrEmpty(this string str) =>
	   string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);

		public static IQueryable<TSource> Paginate<TSource>(this IQueryable<TSource> source, int pageNo, int pageSize)
		{
			return source.Skip((pageNo - 1) * pageSize).Take(pageSize);
		}
	}
}
