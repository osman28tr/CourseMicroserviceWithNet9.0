using Asp.Versioning.Builder;
using CourseMicroservice.Basket.API.Features.Basket.Commands.Create;
using CourseMicroservice.Basket.API.Features.Basket.Commands.Delete;
using CourseMicroservice.Basket.API.Features.Basket.Queries.GetBasket;

namespace CourseMicroservice.Basket.API.Features.Basket
{
	public static class BasketEndpointExt
	{
		public static void AddBasketEndpointExt(this WebApplication application, ApiVersionSet apiVersionSet)
		{
			application.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
				.WithApiVersionSet(apiVersionSet)
				.AddBasketItemGroupItemEndpoint()
				.DeleteBasketItemGroupItemEndpoint()
				.GetBasketGroupItemEndpoint();
		}
	}
}
