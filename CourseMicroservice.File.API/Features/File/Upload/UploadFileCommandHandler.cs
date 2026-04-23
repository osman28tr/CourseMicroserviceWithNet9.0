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
				var fileExtension = Path.GetExtension(request.File.FileName);

				var newFileName = $"{Guid.NewGuid()}{fileExtension}";

				var fileVirtualPath = GetFileVirtualPath(fileExtension);

				var filePath = Path.Combine(fileProvider.GetFileInfo(fileVirtualPath).PhysicalPath!, newFileName);

				using var stream = new FileStream(filePath, FileMode.Create);

				await request.File.CopyToAsync(stream, cancellationToken);

				var response = new UploadFileCommandResponse(newFileName, $"{fileVirtualPath}/{newFileName}", request.File.FileName);

				return ServiceResponse<UploadFileCommandResponse>.SuccessAsCreated(response, filePath);
			}
			catch
			{
				return ServiceResponse<UploadFileCommandResponse>.Error("File upload failed", "", HttpStatusCode.InternalServerError);
			}
		}
		public string GetFileVirtualPath(string fileExtension)
		{
			return fileExtension switch
			{
				".doc" or ".docx" => "files/word",
				".xls" or ".xlsx" => "files/excel",
				".pdf" => "files/pdf",
				".jpg" or ".jpeg" or ".png" or ".gif" => "files/image",
				_ => "files/other"
			};
		}
	}
}
