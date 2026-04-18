using CourseMicroservice.Basket.API.Features.Basket.Commands.Create;
using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using MediatR;

namespace CourseMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon
{
	public static class ApplyDiscountCouponEndpoint
	{
		public static RouteGroupBuilder ApplyDiscountCouponGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapPut("/applyDiscountRate",
				async (ApplyDiscountCouponCommand command, IMediator mediator) =>
					(await mediator.Send(command)).ToGenericResult())
				.MapToApiVersion(1, 0)
			.AddEndpointFilter<ValidationFilter<ApplyDiscountCouponCommandValidator>>();
			return routeGroupBuilder;
		}
	}
}
