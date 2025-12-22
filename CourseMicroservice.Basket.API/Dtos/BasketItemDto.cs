namespace CourseMicroservice.Basket.API.Dtos
{
	public record BasketItemDto(Guid CourseId, string CourseName, decimal CoursePrice, string CourseImageUrl, decimal? PriceByApplyDiscountRate)
	{
		
	}
}
