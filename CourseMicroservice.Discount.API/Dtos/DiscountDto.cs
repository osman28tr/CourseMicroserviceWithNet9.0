namespace CourseMicroservice.Discount.API.Dtos
{
	public class DiscountDto
	{
		public float Rate { get; set; }
		public string Code { get; set; }
		public DateTime? ExpireDate { get; set; }
	}
}
