using CourseMicroservice.Basket.API.Features.Basket.Commands.Create;
using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using MediatR;

namespace CourseMicroservice.Basket.API.Features.Basket.Queries.GetBasket
{
	public static class GetBasketQueryEndpoint
	{
		public static RouteGroupBuilder GetBasketGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapGet("/user",
				async (IMediator mediator) =>
					(await mediator.Send(new GetBasketQuery())).ToGenericResult())
				.MapToApiVersion(1, 0);
			return routeGroupBuilder;
		}
	}
}
