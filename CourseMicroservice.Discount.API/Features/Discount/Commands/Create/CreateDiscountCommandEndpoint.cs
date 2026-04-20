using CourseMicroservice.Shared.Filters;

namespace CourseMicroservice.Discount.API.Features.Discount.Commands.Create
{
	public static class CreateDiscountCommandEndpoint
	{
		public static RouteGroupBuilder CreateDiscountGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapPost("/",
				async (CreateDiscountCommand command, IMediator mediator) =>
					(await mediator.Send(command)).ToGenericResult())
				.MapToApiVersion(1, 0)
			.AddEndpointFilter<ValidationFilter<CreateDiscountCommandValidator>>();
			return routeGroupBuilder;
		}
	}
}
