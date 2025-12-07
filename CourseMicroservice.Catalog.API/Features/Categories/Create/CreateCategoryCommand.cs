using CourseMicroservice.Shared.Responses;
using MediatR;

namespace CourseMicroservice.Catalog.API.Features.Categories.Create
{
	public record class CreateCategoryCommand(string name) : IRequest<ServiceResponse<CreateCategoryResponse>>;
}
