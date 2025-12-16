using CourseMicroservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservice.Catalog.API.Features.Courses.Commands.Create
{
	public static class CreateCourseEndpoint
	{
		public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapPost("/",
				async (IMediator mediator, CreateCourseCommand createCourseCommand) =>
					(await mediator.Send(createCourseCommand)).ToGenericResult())
				.MapToApiVersion(1,0)
				.Produces<Guid>(StatusCodes.Status201Created)
				.Produces(StatusCodes.Status404NotFound)
				.Produces(StatusCodes.Status400BadRequest)
				.Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
				.AddEndpointFilter<ValidationFilter<CreateCourseCommand>>();
			return routeGroupBuilder;
		}
	}
}
