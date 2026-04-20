using FluentValidation;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.ApplyDiscountCoupon
{
	public class ApplyDiscountCouponCommandValidator : AbstractValidator<ApplyDiscountCouponCommand>
	{
		public ApplyDiscountCouponCommandValidator()
		{
			RuleFor(x => x.Coupon).NotEmpty().WithMessage("{PropertyName} is required");
			RuleFor(x => x.Rate).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
		}
	}
}
