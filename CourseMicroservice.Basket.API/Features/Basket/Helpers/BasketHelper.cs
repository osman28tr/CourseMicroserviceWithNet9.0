using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Data;
using CourseMicroservice.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseMicroservice.Basket.API.Features.Basket.Helpers
{
	public class BasketHelper(IIdentityService identityService,IDistributedCache distributedCache)
	{
		private string GetCacheKey() => string.Format(BasketConst.BasketCacheKey, identityService.UserId);		
		public Task<string?> GetBasketFromCacheAsync(CancellationToken cancellationToken)
		{
			var hasBasket = distributedCache.GetStringAsync(GetCacheKey(), cancellationToken);

			return hasBasket;
		}

		public async Task SetBasketCacheAsync(Data.Basket basket,CancellationToken cancellationToken)
		{
			var basketAsJsonString = JsonSerializer.Serialize(basket);

			await distributedCache.SetStringAsync(GetCacheKey(), basketAsJsonString);
		}
	}
}
