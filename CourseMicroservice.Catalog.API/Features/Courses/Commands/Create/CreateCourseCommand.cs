using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Catalog.API.Features.Courses.Commands.Create
{
	public record class CreateCourseCommand(string Name,string Description, decimal Price, string? PictureUrl,Guid categoryId) : IRequestByServiceResponse<Guid>;
}
