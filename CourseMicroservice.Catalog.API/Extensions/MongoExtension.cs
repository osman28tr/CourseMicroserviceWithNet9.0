using CourseMicroservice.Catalog.API.Options;
using Microsoft.Extensions.Options;

namespace CourseMicroservice.Catalog.API.Extensions
{
	public static class MongoExtension
	{
		public static IServiceCollection AddMongoOption(this IServiceCollection services)
		{
			services.AddOptions<MongoOption>().BindConfiguration(nameof(MongoOption)).ValidateDataAnnotations().ValidateOnStart();

			services.AddSingleton(opt => opt.GetRequiredService<IOptions<MongoOption>>().Value);

			return services;
		}
	}
}
