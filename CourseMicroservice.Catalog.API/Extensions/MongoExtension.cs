using CourseMicroservice.Catalog.API.Options;

namespace CourseMicroservice.Catalog.API.Extensions
{
	public static class MongoExtension
	{
		public static IServiceCollection AddMongoOption(this IServiceCollection services)
		{
			services.AddOptions<MongoOption>().BindConfiguration(nameof(MongoOption)).ValidateDataAnnotations().ValidateOnStart();
			return services;
		}
	}
}
