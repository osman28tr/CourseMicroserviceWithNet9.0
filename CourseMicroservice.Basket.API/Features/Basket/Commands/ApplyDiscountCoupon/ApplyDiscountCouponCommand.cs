using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.ApplyDiscountCoupon
{
	public record ApplyDiscountCouponCommand (string Coupon,float Rate) : IRequestByServiceResponse
	{
	}
}
