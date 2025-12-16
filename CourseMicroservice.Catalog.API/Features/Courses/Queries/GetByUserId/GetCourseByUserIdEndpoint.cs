using CourseMicroservice.Catalog.API.Features.Courses.Dtos;
using CourseMicroservice.Shared.Responses;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Catalog.API.Features.Courses.Queries.GetByUserId
{
	public class GetCourseByUserIdQuery : IRequestByServiceResponse<CourseDto>
	{
		public Guid UserId { get; set; } = default!;
	}
	public class GetCourseByUserIdQueryHandler(IMapper mapper,AppDbContext context) : IRequestHandler<GetCourseByUserIdQuery, ServiceResponse<CourseDto>>
	{
		public async Task<ServiceResponse<CourseDto>> Handle(GetCourseByUserIdQuery request, CancellationToken cancellationToken)
		{
			var course = await context.Courses.FirstOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken: cancellationToken);
			if (course is null)
			{
				return (ServiceResponse<CourseDto>)ServiceResponse<CourseDto>.ErrorAsNotFound();
			}
			var mappedCourse = mapper.Map<CourseDto>(course);
			return ServiceResponse<CourseDto>.SuccessAsOk(mappedCourse);
		}
	}
	public static class GetCourseByUserIdEndpoint
	{
		public static RouteGroupBuilder GetCourseByUserIdGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			 routeGroupBuilder.MapGet("/GetByUserId/{userId : guid}",
				async (IMediator mediator, Guid userId) =>
					(await mediator.Send(new GetCourseByUserIdQuery { UserId = userId })).ToGenericResult()).MapToApiVersion(1,0);
			return routeGroupBuilder;
		}
	}
}
