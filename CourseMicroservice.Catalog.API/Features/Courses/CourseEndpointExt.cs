using CourseMicroservice.Catalog.API.Features.Categories.Create;
using CourseMicroservice.Catalog.API.Features.Courses.Create;

namespace CourseMicroservice.Catalog.API.Features.Courses
{
	public static class CourseEndpointExt
	{
		public static void AddCourseEndpointExt(this WebApplication application)
		{
			application.MapGroup("api/courses").WithTags("Courses").CreateCourseGroupItemEndpoint();				
		}
	}
}
