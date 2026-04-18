using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Data;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace CourseMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon
{
	public class ApplyDiscountCouponCommandHandler(IIdentityService identityService, IDistributedCache distributedCache) :
		IRequestHandler<ApplyDiscountCouponCommand, ServiceResponse>
	{
		public async Task<ServiceResponse> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
		{
			Guid userId = identityService.UserId;
			var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

			var hasBasket = await distributedCache.GetStringAsync(cacheKey, cancellationToken);

			if(string.IsNullOrEmpty(hasBasket))
				ServiceResponse<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);

			var basket = JsonSerializer.Deserialize<Data.Basket>(hasBasket);

			if (!basket.BasketItems.Any())
			{
				return ServiceResponse.Error("Basket items are not found", HttpStatusCode.NotFound);
			}

			basket.ApplyCoupon(request.Coupon, request.Rate);

			var basketJsonString = JsonSerializer.Serialize(basket);

			await distributedCache.SetStringAsync(cacheKey, basketJsonString, cancellationToken);

			return ServiceResponse.SuccessAsNoContent();
		}
	}
}
