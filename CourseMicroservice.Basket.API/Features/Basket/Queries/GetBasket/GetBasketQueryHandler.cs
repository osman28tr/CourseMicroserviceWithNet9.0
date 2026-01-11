using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace CourseMicroservice.Basket.API.Features.Basket.Queries.GetBasket
{
	public class GetBasketQueryHandler(IDistributedCache distributedCache,IIdentityService identityService) : IRequestHandler<GetBasketQuery, ServiceResponse<BasketDto>>
	{
		public async Task<ServiceResponse<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
		{
			//basket : userId
			Guid userId = identityService.UserId;
			var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

			var hasBasket = await distributedCache.GetStringAsync(cacheKey, cancellationToken);

			if (string.IsNullOrEmpty(hasBasket))
			{
				ServiceResponse<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);
			}

			var basketDto = JsonSerializer.Deserialize<BasketDto>(hasBasket);
			return ServiceResponse<BasketDto>.SuccessAsOk(basketDto);
		}
	}
}
