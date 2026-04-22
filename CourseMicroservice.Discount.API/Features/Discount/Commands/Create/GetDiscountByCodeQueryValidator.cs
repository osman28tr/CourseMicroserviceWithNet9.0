using CourseMicroservice.Discount.API.Features.Discount.Queries.GetDiscountByCode;

namespace CourseMicroservice.Discount.API.Features.Discount.Commands.Create
{
	public class GetDiscountByCodeQueryValidator : AbstractValidator<GetDiscountByCodeQuery>
	{
		public GetDiscountByCodeQueryValidator()
		{
			RuleFor(x => x.Code)
				.NotEmpty().WithMessage("Code is required.");
		}
	}
}
