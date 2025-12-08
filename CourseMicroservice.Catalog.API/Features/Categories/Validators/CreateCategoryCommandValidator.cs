using CourseMicroservice.Catalog.API.Features.Categories.Create;
using FluentValidation;

namespace CourseMicroservice.Catalog.API.Features.Categories.Validators
{
	public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
	{
		public CreateCategoryCommandValidator()
		{
			RuleFor(x => x.name).NotEmpty().WithMessage("{PropertyName} cannot be empty").Length(4, 25)
				.WithMessage("{PropertyName} must be between 4 and 25 characters");
		}
	}
}
