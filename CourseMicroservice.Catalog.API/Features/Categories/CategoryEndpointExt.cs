using CourseMicroservice.Catalog.API.Features.Categories.Create;
using CourseMicroservice.Catalog.API.Features.Categories.GetAll;
using CourseMicroservice.Catalog.API.Features.Categories.GetById;

namespace CourseMicroservice.Catalog.API.Features.Categories
{
	public static class CategoryEndpointExt
	{
		public static void AddCategoryEndpointExt(this WebApplication application)
		{
			application.MapGroup("api/categories").CreateCategoryGroupItemEndpoint()
				.GetAllCategoryGroupItemEndpoint()
				.GetByIdCategoryGroupItemEndpoint();
		}
	}
}
