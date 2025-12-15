using CourseMicroservice.Shared.Responses;

namespace CourseMicroservice.Catalog.API.Features.Courses.Commands.Update
{
	public class UpdateCourseCommandHandler(IMapper mapper,AppDbContext context) : IRequestHandler<UpdateCourseCommand, ServiceResponse<UpdateCourseCommand>>
	{
		public async Task<ServiceResponse<UpdateCourseCommand>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
		{
			var course = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id);
			if (course is null)
			{
				return ServiceResponse<UpdateCourseCommand>.Error("Course not found", $"The course with Id {request.Id} was not found", System.Net.HttpStatusCode.NotFound);
			}
			var mappedCourse = mapper.Map<UpdateCourseCommand, Course>(request, course);
			context.Courses.Update(course);
			context.SaveChanges();
			return ServiceResponse<UpdateCourseCommand>.SuccessAsOk(request);
		}
	}
}
