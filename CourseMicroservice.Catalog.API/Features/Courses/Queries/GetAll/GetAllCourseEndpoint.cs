using CourseMicroservice.Catalog.API.Features.Categories.GetAll;
using CourseMicroservice.Catalog.API.Features.Courses.Dtos;
using CourseMicroservice.Shared.Responses;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Catalog.API.Features.Courses.Queries.GetAll
{
	public class GetAllCourseQuery : IRequestByServiceResponse<List<CourseDto>>;
	public class GetAllCourseQueryHandler(IMapper mapper,AppDbContext context) : IRequestHandler<GetAllCourseQuery, ServiceResponse<List<CourseDto>>>
	{
		public async Task<ServiceResponse<List<CourseDto>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
		{
			var courses = await context.Courses.ToListAsync(cancellationToken: cancellationToken);
			var mappedCourses = mapper.Map<List<CourseDto>>(courses);
			return ServiceResponse<List<CourseDto>>.SuccessAsOk(mappedCourses);
		}
	}

	public static class GetAllCourseEndpoint
	{
		public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapGet("/",
				async (IMediator mediator) =>
					(await mediator.Send(new GetAllCourseQuery())).ToGenericResult());
			return routeGroupBuilder;
		}
	}
}
