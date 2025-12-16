using CourseMicroservice.Catalog.API.Features.Courses.Dtos;
using CourseMicroservice.Shared.Responses;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Catalog.API.Features.Courses.Queries.GetById
{
	public class GetByIdCourseQuery : IRequestByServiceResponse<CourseDto> {
		public Guid Id { get; set; }
	} 
	public class GetByIdCourseQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetByIdCourseQuery, ServiceResponse<CourseDto>>
	{
		public async Task<ServiceResponse<CourseDto>> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
		{
			var course = await context.Courses.FindAsync(request.Id, cancellationToken);
			if (course is null)
			{
				return ServiceResponse<CourseDto>.Error("Course not found", $"The course with Id {request.Id} was not found", HttpStatusCode.NotFound);
			}
			var mappedCourse = mapper.Map<CourseDto>(course);
			return ServiceResponse<CourseDto>.SuccessAsOk(mappedCourse);
		}
	}
	public static class GetByIdCourseEndpoint
	{
		public static RouteGroupBuilder GetByIdCourseGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapGet("/{id:guid}",
				async (IMediator mediator, Guid id) =>
					(await mediator.Send(new GetByIdCourseQuery { Id = id })).ToGenericResult()).MapToApiVersion(1,0);
			return routeGroupBuilder;
		}
	}
}
