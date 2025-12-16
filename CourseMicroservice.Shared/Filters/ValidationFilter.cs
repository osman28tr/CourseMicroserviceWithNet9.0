using CourseMicroservice.Shared.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Shared.Filters
{
	public class ValidationFilter<T> : IEndpointFilter
	{
		public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
		{
			var hasValidator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

			//Fast fail
			if(hasValidator is null)
			{
				return await next(context);
			}

			var requestModel = context.Arguments.OfType<T>().FirstOrDefault();
			if(requestModel is null)
			{
				return await next(context);
			}

			var validateResult = await hasValidator.ValidateAsync(requestModel);
			if (!validateResult.IsValid)
			{
				return Results.ValidationProblem(validateResult.ToDictionary());
			}

			return await next(context);
		}
	}
}
