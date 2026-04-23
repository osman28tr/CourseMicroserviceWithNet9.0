using CourseMicroservice.Discount.API.Dtos;
using CourseMicroservice.Discount.API.Repositories;
using CourseMicroservice.Shared.Responses;

namespace CourseMicroservice.Discount.API.Features.Discount.Queries.GetDiscountByCode
{
	public class GetDiscountByCodeQueryHandler(AppDbContext appDbContext) : IRequestHandler<GetDiscountByCodeQuery, ServiceResponse<DiscountDto>>
	{
		public async Task<ServiceResponse<DiscountDto>> Handle(GetDiscountByCodeQuery request, CancellationToken cancellationToken)
		{
			var discount = appDbContext.Discounts.FirstOrDefault(d => d.Code == request.Code);
			if (discount == null)
				return ServiceResponse<DiscountDto>.Error("Not Found", $"Discount with code {request.Code} not found.", HttpStatusCode.NotFound);

			var discountDto = new DiscountDto
			{
				Code = request.Code,
				Rate = discount.Rate,
				ExpireDate = discount.ExpireDate
			};

			if(discount.ExpireDate.HasValue && discount.ExpireDate.Value < DateTime.UtcNow)
				return ServiceResponse<DiscountDto>.Error("Expired", $"Discount with code {request.Code} has expired.", HttpStatusCode.BadRequest);

			return ServiceResponse<DiscountDto>.SuccessAsOk(discountDto);
		}
	}
}
