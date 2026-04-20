using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Basket.API.Features.Basket.Commands.ApplyDiscountCoupon;
using CourseMicroservice.Basket.API.Features.Basket.Helpers;
using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.RemoveDiscountCoupon
{
	public record RemoveDiscountCouponCommand : IRequestByServiceResponse;
	public class RemoveDiscountCouponCommandHandler(IIdentityService identityService,IDistributedCache distributedCache,BasketHelper basketHelper) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResponse>
	{
		public async Task<ServiceResponse> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
		{
			Guid userId = identityService.UserId;
			var hasBasket = await basketHelper.GetBasketFromCacheAsync(cancellationToken);

			if (string.IsNullOrEmpty(hasBasket))
				ServiceResponse<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);

			var basket = JsonSerializer.Deserialize<Data.Basket>(hasBasket);

			basket!.RemoveCoupon();

			await basketHelper.SetBasketCacheAsync(basket, cancellationToken);

			return ServiceResponse.SuccessAsNoContent();
		}
	}

	public static class RemoveDiscountCouponEndpoint
	{
		public static RouteGroupBuilder RemoveDiscountCouponGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapDelete("/removeDiscountRate",
				async (IMediator mediator) =>
					(await mediator.Send(new RemoveDiscountCouponCommand())).ToGenericResult())
				.MapToApiVersion(1, 0);
			return routeGroupBuilder;
		}
	}
}
