namespace CourseMicroservice.Catalog.API.Features.Courses.Commands.Update
{
	public static class UpdateCourseEndpoint
	{
		public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapPut("/",
				async (IMediator mediator, UpdateCourseCommand updateCourseCommand) =>
				{
					return (await mediator.Send(updateCourseCommand)).ToGenericResult();
				}).MapToApiVersion(1,0);
			return routeGroupBuilder;
		}
	}
}
