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

		public static Result<T> Success (string message = "Success", EnumStatusCode statusCode = EnumStatusCode.Success)
		{
			return new Result<T>
			{
				IsSuccess = true,
				Message = message,
				StatusCode = statusCode
			};
		}

		public static Result<T> Success(T data, string message = "Success.", EnumStatusCode statusCode = EnumStatusCode.Success)
		{
			return new Result<T>
			{
				Data = data,
				IsSuccess = true,
				Message = message,
				StatusCode = statusCode
			};
		}

		public static Result<T> SaveSuccess(string message = "Saving Successful.", EnumStatusCode statusCode = EnumStatusCode.Success)
		{
			return new Result<T>
			{
				IsSuccess = true,
				Message = message,
				StatusCode = statusCode
			};
		}

		public static Result<T> UpdateSuccess(string message = "Update Successful.", EnumStatusCode statusCode = EnumStatusCode.Success)
		{
			return new Result<T>
			{
				IsSuccess = true,
				Message = message,
				StatusCode = statusCode
			};
		}
	}
}
