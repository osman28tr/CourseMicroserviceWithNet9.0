using CourseMicroservice.Shared.Responses;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Catalog.API.Features.Courses.Commands.Delete
{
	public class DeleteCourseCommand : IRequestByServiceResponse<DeleteCourseCommand>
	{
		public Guid Id { get; set; }
	}
	public class DeleteCourseCommandHandler(IMapper mapper, AppDbContext context) : IRequestHandler<DeleteCourseCommand, ServiceResponse<DeleteCourseCommand>>
	{
		public async Task<ServiceResponse<DeleteCourseCommand>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
		{
			var course = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id);
			if (course is null)
			{
				return ServiceResponse<DeleteCourseCommand>.Error("Course not found", $"The course with Id {request.Id} was not found", System.Net.HttpStatusCode.NotFound);
			}
			context.Courses.Remove(course);
			context.SaveChanges();
			return ServiceResponse<DeleteCourseCommand>.SuccessAsOk(request);
		}
	}
	public static class DeleteCourseCommandEndpoint
	{
		public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapDelete("/{id:guid}",
				async (IMediator mediator, Guid id) =>
				{
					var deleteCourseCommand = new DeleteCourseCommand { Id = id };
					return (await mediator.Send(deleteCourseCommand)).ToGenericResult();
				});
			return routeGroupBuilder;
		}
	}
}
