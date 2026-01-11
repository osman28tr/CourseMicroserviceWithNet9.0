using CourseMicroservice.Basket.API.Dtos;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Basket.API.Features.Basket.Queries.GetBasket
{
	public record GetBasketQuery : IRequestByServiceResponse<BasketDto>
	{
	}
}
