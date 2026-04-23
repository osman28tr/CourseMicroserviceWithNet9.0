using CourseMicroservice.Shared.Extensions;
using MediatR;

namespace CourseMicroservice.File.API.Features.File.Delete
{
	public static class DeleteFileCommandEndpoint
	{
		public static RouteGroupBuilder DeleteFileGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapDelete("/{fileName}",
				async (string fileName, IMediator mediator) =>
					(await mediator.Send(new DeleteFileCommand(fileName))).ToGenericResult())
				.MapToApiVersion(1, 0).DisableAntiforgery();
			return routeGroupBuilder;
		}
	}
}
