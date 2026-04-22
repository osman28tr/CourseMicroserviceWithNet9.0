using CourseMicroservice.Discount.API.Repositories;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;

namespace CourseMicroservice.Discount.API.Features.Discount.Commands.Create
{
	public class CreateDiscountCommandHandler(IIdentityService identityService,AppDbContext appDbContext) : IRequestHandler<CreateDiscountCommand,ServiceResponse>
	{
		public async Task<ServiceResponse> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
		{
			var hasCodeForUser = await appDbContext.Discounts.AnyAsync(d => d.UserId == identityService.UserId && 
			d.Code == request.Code, cancellationToken);
			if (hasCodeForUser)
			{
				return ServiceResponse.Error("Code already exists for user", 
					$"The code `{request.Code}` is already exists for user", HttpStatusCode.BadRequest);
			}
			var discount = new Discount()
			{
				Id = NewId.NextSequentialGuid(),
				Code = request.Code,
				Rate = request.Rate,
				ExpireDate = request.ExpireDate,
				UserId = identityService.UserId
			};
			
			await appDbContext.Discounts.AddAsync(discount, cancellationToken);

			await appDbContext.SaveChangesAsync();

			return ServiceResponse.SuccessAsNoContent();
		}
	}
}
