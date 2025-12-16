using CourseMicroservice.Shared.Responses;
using MediatR;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Catalog.API.Features.Categories.Create
{
	public record class CreateCategoryCommand(string name) : IRequestByServiceResponse<CreateCategoryCommandResponse>;
}
