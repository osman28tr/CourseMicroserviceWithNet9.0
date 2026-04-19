using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Data;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Basket.API.Features.Basket.Helpers;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.ApplyDiscountCoupon
{
	public class ApplyDiscountCouponCommandHandler(IIdentityService identityService,BasketHelper basketHelper) :
		IRequestHandler<ApplyDiscountCouponCommand, ServiceResponse>
	{
		public async Task<ServiceResponse> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
		{
			Guid userId = identityService.UserId;

			var hasBasket = await basketHelper.GetBasketFromCacheAsync(cancellationToken);

			if (string.IsNullOrEmpty(hasBasket))
				ServiceResponse<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);

			var basket = JsonSerializer.Deserialize<Data.Basket>(hasBasket);

			if (!basket.BasketItems.Any())
			{
				return ServiceResponse.Error("Basket items are not found", HttpStatusCode.NotFound);
			}

			basket.ApplyCoupon(request.Coupon, request.Rate);

			await basketHelper.SetBasketCacheAsync(basket, cancellationToken);

			return ServiceResponse.SuccessAsNoContent();
		}
	}
}
