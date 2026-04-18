using System.Text.Json.Serialization;

namespace CourseMicroservice.Basket.API.Dtos
{
	public class BasketDto
	{
		[JsonIgnore]public Guid UserId { get; init; }
		public List<BasketItemDto> BasketItems { get; set; } = new();
		public float? DiscountRate { get; set; }
		public string? Coupon { get; set; }
		public decimal TotalPrice { get; set; }
		public BasketDto(Guid userId, List<BasketItemDto> basketItems)
		{
			UserId = userId;
			BasketItems = basketItems;
		}
		public BasketDto()
		{			
		}
	}
}
