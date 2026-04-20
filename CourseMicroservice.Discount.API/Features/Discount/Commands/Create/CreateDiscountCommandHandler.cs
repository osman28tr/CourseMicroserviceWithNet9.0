using CourseMicroservice.Discount.API.Repositories;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;

namespace CourseMicroservice.Discount.API.Features.Discount.Commands.Create
{
	public class CreateDiscountCommandHandler(IIdentityService identityService,AppDbContext appDbContext) : IRequestHandler<CreateDiscountCommand,ServiceResponse>
	{
		public async Task<ServiceResponse> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
		{
			var discount = new Discount()
			{
				Id = NewId.NextSequentialGuid(),
				Code = request.Code,
				Rate = request.Rate,
				ExpireDate = request.ExpireDate
			};
			
			await appDbContext.Discounts.AddAsync(discount, cancellationToken);

			await appDbContext.SaveChangesAsync();

			return ServiceResponse.SuccessAsNoContent();
		}
	}
}
