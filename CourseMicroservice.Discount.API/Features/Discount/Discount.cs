using CourseMicroservice.Discount.API.Repositories;

namespace CourseMicroservice.Discount.API.Features.Discount
{
	public class Discount : BaseEntity
	{
		public Guid UserId { get; set; }
		public float Rate { get; set; }
		public string Code { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public DateTime? ExpireDate { get; set; }
	}
}
