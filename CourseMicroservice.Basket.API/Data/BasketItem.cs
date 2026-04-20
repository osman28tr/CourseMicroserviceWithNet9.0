namespace CourseMicroservice.Basket.API.Data
{
	public class BasketItem
	{
		public BasketItem(Guid courseId, string courseName, decimal coursePrice, string courseImageUrl, decimal? priceByApplyDiscountRate)
		{
			CourseId = courseId;
			CourseName = courseName;
			CoursePrice = coursePrice;
			CourseImageUrl = courseImageUrl;
			PriceByApplyDiscountRate = priceByApplyDiscountRate;
		}

		public Guid CourseId { get; set; }
		public string CourseName { get; set; }
		public decimal CoursePrice { get; set; }
		public string CourseImageUrl { get; set; }
		public decimal? PriceByApplyDiscountRate { get; set; }
		
	}
}
