using CourseMicroservice.Catalog.API.Features.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection.Emit;

namespace CourseMicroservice.Catalog.API.Repositories
{
	public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.ToCollection("courses");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever();
			builder.Property(x => x.Name).HasElementName("name");
			builder.Property(x => x.Description).HasElementName("description");
			builder.Property(x => x.CreatedDate).HasElementName("createdDate");
			builder.Property(x => x.UserId).HasElementName("userId");
			builder.Property(x => x.CategoryId).HasElementName("categoryId");
			builder.Property(x => x.Picture).HasElementName("picture");
			builder.Ignore(x => x.Category);

			builder.OwnsOne<Feature>(x => x.Feature, feature =>
			{
				feature.Property(x => x.Duration).HasElementName("duration");
				feature.Property(x => x.EducatorFullName).HasElementName("educatorFullName");
			});
		}
	}
}
