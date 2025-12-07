using CourseMicroservice.Catalog.API.Features.Categories.Create;

namespace CourseMicroservice.Catalog.API.Features.Categories
{
	public static class CategoryEndpointExt
	{
		public static void AddCategoryEndpointExt(this WebApplication application)
		{
			application.MapGroup("api/categories").CreateCategoryGroupItemEndpoint();
		}
	}
}
