using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservice.Catalog.API.Features.Categories.Create
{
	public static class CreateCategoryCommandEndpoint
	{
		public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapPost("/",
				async (CreateCategoryCommand command, IMediator mediator) =>
					(await mediator.Send(command)).ToGenericResult())			
			.AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();
			return routeGroupBuilder;
		}
	}
}
