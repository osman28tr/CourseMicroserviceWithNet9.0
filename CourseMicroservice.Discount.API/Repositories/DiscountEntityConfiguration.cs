using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CourseMicroservice.Discount.API.Repositories
{
	public class DiscountEntityConfiguration : IEntityTypeConfiguration<Features.Discount.Discount>
	{
		public void Configure(EntityTypeBuilder<Features.Discount.Discount> builder)
		{
			builder.ToCollection("discounts");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever();
			builder.Property(x => x.UserId).HasElementName("user_id");
			builder.Property(x => x.Code).HasElementName("code");
			builder.Property(x => x.CreatedDate).HasElementName("createdDate");
			builder.Property(x => x.UpdatedDate).HasElementName("updatedDate");
			builder.Property(x => x.ExpireDate).HasElementName("expireDate");
		}
	}
}
