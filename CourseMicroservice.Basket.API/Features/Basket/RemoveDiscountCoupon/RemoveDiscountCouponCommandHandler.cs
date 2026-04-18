using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon;
using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Basket.API.Features.Basket.RemoveDiscountCoupon
{
	public record RemoveDiscountCouponCommand : IRequestByServiceResponse;
	public class RemoveDiscountCouponCommandHandler(IIdentityService identityService,IDistributedCache distributedCache) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResponse>
	{
		public async Task<ServiceResponse> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
		{
			Guid userId = identityService.UserId;
			var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

			var hasBasket = await distributedCache.GetStringAsync(cacheKey, cancellationToken);

			if (string.IsNullOrEmpty(hasBasket))
				ServiceResponse<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);

			var basket = JsonSerializer.Deserialize<Data.Basket>(hasBasket);

			basket!.RemoveCoupon();

			var basketAsJsonString = JsonSerializer.Serialize(basket);

			await distributedCache.SetStringAsync(cacheKey, basketAsJsonString);

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
