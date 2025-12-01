using CourseMicroservice.Catalog.API.Features.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection.Emit;

namespace CourseMicroservice.Catalog.API.Repositories
{
	public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToCollection("categories");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasElementName("name");
			builder.Property(x => x.Id).ValueGeneratedNever();
			builder.Ignore(x => x.Courses);
		}
	}
}
