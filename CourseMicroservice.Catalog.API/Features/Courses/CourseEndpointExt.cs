using Asp.Versioning.Builder;
using CourseMicroservice.Catalog.API.Features.Categories.Create;
using CourseMicroservice.Catalog.API.Features.Courses.Commands.Create;
using CourseMicroservice.Catalog.API.Features.Courses.Commands.Delete;
using CourseMicroservice.Catalog.API.Features.Courses.Commands.Update;
using CourseMicroservice.Catalog.API.Features.Courses.Queries.GetAll;
using CourseMicroservice.Catalog.API.Features.Courses.Queries.GetById;
using CourseMicroservice.Catalog.API.Features.Courses.Queries.GetByUserId;

namespace CourseMicroservice.Catalog.API.Features.Courses
{
	public static class CourseEndpointExt
	{
		public static void AddCourseEndpointExt(this WebApplication application,ApiVersionSet apiVersionSet)
		{
			application.MapGroup("api/v{version:apiVersion}/courses").WithTags("Courses")
				.WithApiVersionSet(apiVersionSet)
				.CreateCourseGroupItemEndpoint()
				.GetAllCourseGroupItemEndpoint().GetByIdCourseGroupItemEndpoint().UpdateCourseGroupItemEndpoint().
				DeleteCourseGroupItemEndpoint();
		}
	}
}
