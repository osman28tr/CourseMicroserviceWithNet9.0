namespace CourseMicroservice.Discount.API.Features.Discount.Commands.Create
{
	public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
	{
		public CreateDiscountCommandValidator()
		{
			RuleFor(x => x.Code).NotEmpty().WithMessage("{PropertyName} is required");
			RuleFor(x => x.Rate).NotEmpty().WithMessage("{PropertyName} is required");
			RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} is required");
			RuleFor(x => x.ExpireDate).NotEmpty().WithMessage("{PropertyName} is required");
		}
	}
}
