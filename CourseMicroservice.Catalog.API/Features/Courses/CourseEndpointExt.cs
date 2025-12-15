using CourseMicroservice.Catalog.API.Features.Categories.Create;
using CourseMicroservice.Catalog.API.Features.Courses.Commands.Create;
using CourseMicroservice.Catalog.API.Features.Courses.Commands.Delete;
using CourseMicroservice.Catalog.API.Features.Courses.Commands.Update;
using CourseMicroservice.Catalog.API.Features.Courses.Queries.GetAll;
using CourseMicroservice.Catalog.API.Features.Courses.Queries.GetById;

namespace CourseMicroservice.Catalog.API.Features.Courses
{
	public static class CourseEndpointExt
	{
		public static void AddCourseEndpointExt(this WebApplication application)
		{
			application.MapGroup("api/courses").WithTags("Courses").CreateCourseGroupItemEndpoint()
				.GetAllCourseGroupItemEndpoint().GetByIdCourseGroupItemEndpoint().UpdateCourseGroupItemEndpoint().
				DeleteCourseGroupItemEndpoint();
		}
	}
}
