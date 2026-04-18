using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon
{
	public record ApplyDiscountCouponCommand (string Coupon,float Rate) : IRequestByServiceResponse
	{
	}
}
