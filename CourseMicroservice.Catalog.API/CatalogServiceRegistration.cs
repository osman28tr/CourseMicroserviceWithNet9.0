using CourseMicroservice.Catalog.API.Features.Categories.Rules;
using CourseMicroservice.Catalog.API.Features.Courses.Rules;

namespace CourseMicroservice.Catalog.API
{
	public static class CatalogServiceRegistration
	{
		public static IServiceCollection AddCatalogServiceRegistration(this IServiceCollection services)
		{
			services.AddScoped<ICategoryRule, CategoryRule>();
			services.AddScoped<ICourseRule, CourseRule>();
			return services;
		}
	}
}
