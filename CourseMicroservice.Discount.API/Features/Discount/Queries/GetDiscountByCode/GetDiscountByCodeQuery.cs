using CourseMicroservice.Discount.API.Dtos;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Discount.API.Features.Discount.Queries.GetDiscountByCode
{
	public record GetDiscountByCodeQuery(string Code) : IRequestByServiceResponse<DiscountDto>;
}
