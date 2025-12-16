using MediatR;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CourseMicroservice.Shared.Responses
{
	public class ServiceResponse
	{

		public interface IRequestByServiceResponse<T> : IRequest<ServiceResponse<T>>;

		[JsonIgnore] public HttpStatusCode Status { get; set; }

		public ProblemDetails? Fail { get; set; }

		[JsonIgnore] public bool IsSuccess => Fail is null;
		[JsonIgnore] public bool IsFail => !IsSuccess;


		// Static factory methods
		public static ServiceResponse SuccessAsNoContent()
		{
			return new ServiceResponse
			{
				Status = HttpStatusCode.NoContent
			};
		}

		public static ServiceResponse ErrorAsNotFound()
		{
			return new ServiceResponse
			{
				Status = HttpStatusCode.NotFound,
				Fail = new ProblemDetails
				{
					Title = "Not Found",
					Detail = "The requested resource was not found"
				}
			};
		}


		public static ServiceResponse Error(ProblemDetails problemDetails, HttpStatusCode status)
		{
			return new ServiceResponse
			{
				Status = status,
				Fail = problemDetails
			};
		}

		public static ServiceResponse Error(string title, string description, HttpStatusCode status)
		{
			return new ServiceResponse
			{
				Status = status,
				Fail = new ProblemDetails
				{
					Title = title,
					Detail = description,
					Status = status.GetHashCode()
				}
			};
		}

		public static ServiceResponse Error(string title, HttpStatusCode status)
		{
			return new ServiceResponse
			{
				Status = status,
				Fail = new ProblemDetails
				{
					Title = title,
					Status = status.GetHashCode()
				}
			};
		}

		public static ServiceResponse ErrorFromProblemDetails(ApiException exception)
		{
			if (string.IsNullOrEmpty(exception.Content))
				return new ServiceResponse
				{
					Fail = new ProblemDetails
					{
						Title = exception.Message
					},
					Status = exception.StatusCode
				};

			var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(exception.Content,
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});


			return new ServiceResponse
			{
				Fail = problemDetails,
				Status = exception.StatusCode
			};
		}

		public static ServiceResponse ErrorFromValidation(IDictionary<string, object?> errors)
		{
			return new ServiceResponse
			{
				Status = HttpStatusCode.BadRequest,
				Fail = new ProblemDetails
				{
					Title = "Validation errors occured",
					Detail = "Please check the errors property for more details",
					Extensions = errors,
					Status = HttpStatusCode.BadRequest.GetHashCode()
				}
			};
		}
	}
	public class ServiceResponse<T> : ServiceResponse
	{
		public T? Data { get; set; }
		[JsonIgnore] public string? UrlAsCreated { get; set; }

		public static ServiceResponse<T> SuccessAsOk(T data)
		{
			return new ServiceResponse<T>
			{
				Status = HttpStatusCode.OK,
				Data = data
			};
		}

		public static ServiceResponse<T> SuccessAsCreated(T data, string url)
		{
			return new ServiceResponse<T>
			{
				Status = HttpStatusCode.Created,
				Data = data,
				UrlAsCreated = url
			};
		}
		public static ServiceResponse<T> Error(string title, string description, HttpStatusCode status)
		{
			return new ServiceResponse<T>
			{
				Status = status,
				Fail = new ProblemDetails
				{
					Title = title,
					Detail = description,
					Status = status.GetHashCode()
				}
			};
		}
	}
}
