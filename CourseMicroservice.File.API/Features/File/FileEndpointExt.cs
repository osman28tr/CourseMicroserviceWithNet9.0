using Asp.Versioning.Builder;
using CourseMicroservice.File.API.Features.File.Delete;
using CourseMicroservice.File.API.Features.File.Upload;

namespace CourseMicroservice.File.API.Features.File
{
	public static class FileEndpointExt
	{
		public static void AddFileGroupEndpointExt(this WebApplication application, ApiVersionSet apiVersionSet)
		{
			application.MapGroup("api/v{version:apiVersion}/files").WithTags("Files")
				.WithApiVersionSet(apiVersionSet)
				.UploadFileGroupItemEndpoint()
				.DeleteFileGroupItemEndpoint();
		}
	}
}
