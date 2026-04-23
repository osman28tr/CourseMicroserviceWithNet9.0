using CourseMicroservice.Shared.Responses;
using MediatR;
using Microsoft.Extensions.FileProviders;
using System.Net;

namespace CourseMicroservice.File.API.Features.File.Upload
{
	public class UploadFileCommandHandler(IFileProvider fileProvider) : IRequestHandler<UploadFileCommand, ServiceResponse<UploadFileCommandResponse>>
	{
		public async Task<ServiceResponse<UploadFileCommandResponse>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
		{
			try
			{
				if (request.File.Length == 0)
				{
					return ServiceResponse<UploadFileCommandResponse>.Error("File is empty", "The uploaded file is empty.", HttpStatusCode.BadRequest);

				}

				var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";

				var filePath = Path.Combine(fileProvider.GetFileInfo("files").PhysicalPath!, newFileName);

				using var stream = new FileStream(filePath, FileMode.Create);

				await request.File.CopyToAsync(stream, cancellationToken);

				var response = new UploadFileCommandResponse(newFileName, $"files/{newFileName}", request.File.FileName);

				return ServiceResponse<UploadFileCommandResponse>.SuccessAsCreated(response, filePath);
			}
			catch (Exception ex)
			{
				return ServiceResponse<UploadFileCommandResponse>.Error("File upload failed", "", HttpStatusCode.InternalServerError);
			}
		}
	}
}
