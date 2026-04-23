using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using MediatR;

namespace CourseMicroservice.File.API.Features.File.Upload
{
	public static class UploadFileCommandEndpoint
	{
		public static RouteGroupBuilder UploadFileGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapPost("/",
				async (IFormFile file, IMediator mediator) =>
					(await mediator.Send(new UploadFileCommand(file))).ToGenericResult())
				.MapToApiVersion(1, 0).DisableAntiforgery();
			return routeGroupBuilder;
		}
	}
}
