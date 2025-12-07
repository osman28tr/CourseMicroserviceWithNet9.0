using CourseMicroservice.Catalog.API.Features.Categories.Rules;

namespace CourseMicroservice.Catalog.API
{
	public static class CatalogServiceRegistration
	{
		public static IServiceCollection AddCatalogServiceRegistration(this IServiceCollection services)
		{
			services.AddScoped<ICategoryRule, CategoryRule>();
			return services;
		}
	}
}
