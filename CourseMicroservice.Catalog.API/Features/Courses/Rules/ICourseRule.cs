using CourseMicroservice.Shared.Responses;

namespace CourseMicroservice.Catalog.API.Features.Courses.Rules
{
	public interface ICourseRule
	{
		Task<ServiceResponse<Guid>> IsExistCourseAndCategoryAsync(AppDbContext context, string courseName, string categoryId);
	}
}
