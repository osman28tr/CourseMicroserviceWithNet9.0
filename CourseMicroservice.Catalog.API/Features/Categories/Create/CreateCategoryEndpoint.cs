using CourseMicroservice.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservice.Catalog.API.Features.Categories.Create
{
	public static class CreateCategoryEndpoint
	{
		public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) => await mediator.Send(command));
			//test test 2
			return routeGroupBuilder;
		}
	}
}
