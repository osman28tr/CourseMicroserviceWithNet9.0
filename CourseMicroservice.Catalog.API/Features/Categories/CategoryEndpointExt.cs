using CourseMicroservice.Catalog.API.Features.Categories.Create;
using CourseMicroservice.Catalog.API.Features.Categories.GetAll;

namespace CourseMicroservice.Catalog.API.Features.Categories
{
	public static class CategoryEndpointExt
	{
		public static void AddCategoryEndpointExt(this WebApplication application)
		{
			application.MapGroup("api/categories").CreateCategoryGroupItemEndpoint()
				.GetAllCategoryGroupItemEndpoint();
		}
	}
}
