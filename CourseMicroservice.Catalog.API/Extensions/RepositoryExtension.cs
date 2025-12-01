using CourseMicroservice.Catalog.API.Options;
using CourseMicroservice.Catalog.API.Repositories;
using MongoDB.Driver;

namespace CourseMicroservice.Catalog.API.Extensions
{
	public static class RepositoryExtension
	{
		public static IServiceCollection AddDbServiceExt(this IServiceCollection services)
		{
			services.AddSingleton<IMongoClient, MongoClient>(sp =>
			{
				var options = sp.GetRequiredService<MongoOption>();
				return new MongoClient(options.ConnectionString);
			});

			services.AddScoped(sp =>
			{
				var mongoClient = sp.GetRequiredService<MongoClient>();
				var options = sp.GetRequiredService<MongoOption>();

				return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
			});

			return services;
		}
	}
}
