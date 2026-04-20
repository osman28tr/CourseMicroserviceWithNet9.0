namespace CourseMicroservice.Basket.API.Data
{
	public class Basket //basket standard model to rich domain modal(behavior + data)
	{
		public Guid UserId { get; set; }
		public List<BasketItem> BasketItems { get; set; } = new();
		public float? DiscountRate { get; set; }
		public string? Coupon { get; set; }
		public bool IsApplyCoupon => DiscountRate > 0 && !string.IsNullOrEmpty(Coupon);
		public decimal TotalPrice => !IsApplyCoupon ? BasketItems.Sum(x=>x.CoursePrice) 
			: BasketItems.Sum(i => i.PriceByApplyDiscountRate ?? i.CoursePrice);

		public Basket(Guid userId,List<BasketItem> basketItems)
		{
			UserId = userId;
			BasketItems = basketItems;
		}
		public Basket()
		{			
		}

		public void ApplyCoupon(string coupon, float discountRate)
		{
			Coupon = coupon;
			DiscountRate = discountRate;
			foreach (var item in BasketItems)
			{
				item.PriceByApplyDiscountRate = item.CoursePrice - (item.CoursePrice * (decimal)discountRate / 100);
			}
		}

		public void RemoveCoupon()
		{
			Coupon = null;
			DiscountRate = null;
			foreach (var item in BasketItems)
			{
				item.PriceByApplyDiscountRate = null;
			}
		}
	}
}
