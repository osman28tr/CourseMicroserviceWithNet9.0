using Asp.Versioning.Builder;
using CourseMicroservice.Basket.API.Features.Basket.Commands;

namespace CourseMicroservice.Basket.API.Features.Basket
{
	public static class BasketEndpointExt
	{
		public static void AddBasketEndpointExt(this WebApplication application, ApiVersionSet apiVersionSet)
		{
			application.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
				.WithApiVersionSet(apiVersionSet)
				.AddBasketItemGroupItemEndpoint();
		}
	}
}
