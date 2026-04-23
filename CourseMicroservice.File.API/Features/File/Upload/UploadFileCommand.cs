using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.File.API.Features.File.Upload
{
	public record UploadFileCommand(IFormFile File) : IRequestByServiceResponse<UploadFileCommandResponse>;
}
