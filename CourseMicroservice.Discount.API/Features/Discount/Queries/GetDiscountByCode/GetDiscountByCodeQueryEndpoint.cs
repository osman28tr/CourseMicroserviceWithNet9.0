using CourseMicroservice.Discount.API.Features.Discount.Commands.Create;
using CourseMicroservice.Shared.Filters;

namespace CourseMicroservice.Discount.API.Features.Discount.Queries.GetDiscountByCode
{
	public static class GetDiscountByCodeQueryEndpoint
	{
		public static RouteGroupBuilder GetDiscountByCodeGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapGet("/GetDiscountByCode/{code}",
				async (string code, IMediator mediator) =>
					(await mediator.Send(new GetDiscountByCodeQuery(code))).ToGenericResult())
				.MapToApiVersion(1, 0)
			.AddEndpointFilter<ValidationFilter<GetDiscountByCodeQueryValidator>>();
			return routeGroupBuilder;
		}
	}
}
