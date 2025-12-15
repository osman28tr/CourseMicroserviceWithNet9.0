
using CourseMicroservice.Shared.Responses;

namespace CourseMicroservice.Catalog.API.Features.Courses.Rules
{
	public class CourseRule : ICourseRule
	{
		public async Task<ServiceResponse<Guid>> IsExistCourseAndCategoryAsync(AppDbContext context,string courseName, string categoryId)
		{
			var categoryExists = await context.Categories.AnyAsync(c => c.Id.ToString() == categoryId);
			if (!categoryExists)
			{
				return ServiceResponse<Guid>.Error("Category not found", $"The category with Id {categoryId} was not found", System.Net.HttpStatusCode.NotFound);
			}
			var courseExists = await context.Courses.AnyAsync(c => c.Name == courseName);
			return courseExists
				? ServiceResponse<Guid>.Error("Course already exists", $"A course with the name '{courseName}' already exists.", System.Net.HttpStatusCode.BadRequest)
				: ServiceResponse<Guid>.SuccessAsOk(Guid.Empty);
		}
	}
}
