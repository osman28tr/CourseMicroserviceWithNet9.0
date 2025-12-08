using CourseMicroservice.Shared.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Shared.Extensions
{
	public static class EndpointResponseExt
	{
		public static IResult ToGenericResult<T>(this ServiceResponse<T> response)
		{
			return response.Status switch
			{
				HttpStatusCode.OK => Results.Ok(response.Data),
				HttpStatusCode.Created => Results.Created(response.UrlAsCreated, response.Data),
				HttpStatusCode.NotFound => Results.NotFound(response.Fail!),
				_ => Results.Problem(response.Fail!)
			};
		}

		public static IResult ToGenericResult(this ServiceResponse response)
		{
			return response.Status switch
			{
				HttpStatusCode.NoContent => Results.NoContent(),
				HttpStatusCode.NotFound => Results.NotFound(response.Fail!),
				_ => Results.Problem(response.Fail!)
			};
		}
	}
}
