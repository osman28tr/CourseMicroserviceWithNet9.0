using CourseMicroservice.Basket.API.Features.Basket.Commands.Create;
using CourseMicroservice.Shared.Filters;
using CourseMicroservice.Shared.Extensions;
using MediatR;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.Delete
{
	public static class DeleteBasketItemCommandEndpoint
	{
		public static RouteGroupBuilder DeleteBasketItemGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapDelete("/item/{id:guid}",
				async (IMediator mediator, Guid id) =>
				{
					var deleteBasketItemCommand = new DeleteBasketItemCommand(id);
					return (await mediator.Send(deleteBasketItemCommand)).ToGenericResult();
				}).MapToApiVersion(1, 0);
			return routeGroupBuilder;
		}
	}
}
