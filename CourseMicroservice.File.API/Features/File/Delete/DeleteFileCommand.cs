using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.File.API.Features.File.Delete
{
	public record DeleteFileCommand(string FileName) : IRequestByServiceResponse;
}
