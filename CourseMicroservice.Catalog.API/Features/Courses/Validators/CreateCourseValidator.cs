using CourseMicroservice.Catalog.API.Features.Courses.Create;

namespace CourseMicroservice.Catalog.API.Features.Courses.Validators
{
	public class CreateCourseValidator : AbstractValidator<CreateCourseCommand>
	{
		public CreateCourseValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Course name is required.")
				.MaximumLength(100).WithMessage("Course name must not exceed 100 characters.");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Course description is required.")
				.MaximumLength(1000).WithMessage("Course description must not exceed 1000 characters.");
			RuleFor(x => x.Price).GreaterThan(0).WithMessage("Course price must be greater than zero.");			
			RuleFor(x => x.categoryId).NotEmpty().WithMessage("Category ID is required.");
		}
	}
}
