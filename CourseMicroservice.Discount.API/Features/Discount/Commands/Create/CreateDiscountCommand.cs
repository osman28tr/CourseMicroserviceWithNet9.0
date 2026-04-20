using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Discount.API.Features.Discount.Commands.Create
{
	public record CreateDiscountCommand : IRequestByServiceResponse
	{
		public string Code { get; set; }
		public Guid UserId { get; set; }
		public float Rate { get; set; }
		public DateTime ExpireDate { get; set; }
	}
}
