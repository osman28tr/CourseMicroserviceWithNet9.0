using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.Create
{
	public record class AddBasketItemCommand(Guid CourseId, string CourseName, decimal CoursePrice, string CourseImageUrl) : IRequestByServiceResponse<AddBasketItemCommand>
	{		
	}
}
