using CourseMicroservice.Shared.Responses;
using MediatR;
using Microsoft.Extensions.FileProviders;

namespace CourseMicroservice.File.API.Features.File.Delete
{
	public class DeleteFileCommandHandler(IFileProvider fileProvider) : IRequestHandler<DeleteFileCommand, ServiceResponse>
	{
		public async Task<ServiceResponse> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
		{
			var fileInfo = fileProvider.GetFileInfo(Path.Combine("files", request.FileName));
			if (!fileInfo.Exists)
			{
				return ServiceResponse.ErrorAsNotFound(); 
			}
			System.IO.File.Delete(fileInfo.PhysicalPath!);
			return ServiceResponse.SuccessAsNoContent();
		}
	}
}
