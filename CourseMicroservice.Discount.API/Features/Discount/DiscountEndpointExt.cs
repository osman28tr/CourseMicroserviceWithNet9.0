using Asp.Versioning.Builder;
using CourseMicroservice.Discount.API.Features.Discount.Commands.Create;

namespace CourseMicroservice.Discount.API.Features.Discount
{
	public static class DiscountEndpointExt
	{
		public static void AddDiscountEndpointExt(this WebApplication application, ApiVersionSet apiVersionSet)
		{
			application.MapGroup("api/v{version:apiVersion}/discounts").WithTags("Discounts")
				.WithApiVersionSet(apiVersionSet)
				.CreateDiscountGroupItemEndpoint();
		}
	}
}
