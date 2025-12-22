namespace CourseMicroservice.Basket.API.Dtos
{
	public record BasketDto(Guid userId,List<BasketItemDto> basketItemDto)
	{
	}
}
