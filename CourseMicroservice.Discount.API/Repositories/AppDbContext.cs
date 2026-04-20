using CourseMicroservice.Discount.API.Features.Discount;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection;

namespace CourseMicroservice.Discount.API.Repositories
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<Features.Discount.Discount> Discounts { get; set; }
		public static AppDbContext Create(IMongoDatabase database)
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName);
			return new AppDbContext(optionsBuilder.Options);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
