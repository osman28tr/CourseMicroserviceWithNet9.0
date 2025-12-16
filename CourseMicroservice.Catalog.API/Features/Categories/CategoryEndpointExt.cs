using Asp.Versioning.Builder;
using CourseMicroservice.Catalog.API.Features.Categories.Create;
using CourseMicroservice.Catalog.API.Features.Categories.GetAll;
using CourseMicroservice.Catalog.API.Features.Categories.GetById;

namespace CourseMicroservice.Catalog.API.Features.Categories
{
	public static class CategoryEndpointExt
	{
		public static void AddCategoryEndpointExt(this WebApplication application,ApiVersionSet apiVersionSet)
		{
			application.MapGroup("api/v{version:apiVersion}/categories").WithTags("Categories")
				.WithApiVersionSet(apiVersionSet)
				.CreateCategoryGroupItemEndpoint()
				.GetAllCategoryGroupItemEndpoint()
				.GetByIdCategoryGroupItemEndpoint();
		}
	}
}
