using CourseMicroservice.Discount.API.Options;
using CourseMicroservice.Discount.API.Repositories;
using MongoDB.Driver;

namespace CourseMicroservice.Discount.API.Extensions
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
				var mongoClient = sp.GetRequiredService<IMongoClient>();
				var options = sp.GetRequiredService<MongoOption>();

				return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
			});

			return services;
		}
	}
}
