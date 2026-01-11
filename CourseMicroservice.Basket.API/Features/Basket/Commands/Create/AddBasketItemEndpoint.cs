using CourseMicroservice.Shared.Filters;
using CourseMicroservice.Shared.Extensions;
using MediatR;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.Create
{
	public static class AddBasketItemEndpoint
	{
		public static RouteGroupBuilder AddBasketItemGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapPost("/item",
				async (AddBasketItemCommand command, IMediator mediator) =>
					(await mediator.Send(command)).ToGenericResult())
				.MapToApiVersion(1, 0)
			.AddEndpointFilter<ValidationFilter<AddBasketItemCommandValidator>>();
			return routeGroupBuilder;
		}
	}
}
