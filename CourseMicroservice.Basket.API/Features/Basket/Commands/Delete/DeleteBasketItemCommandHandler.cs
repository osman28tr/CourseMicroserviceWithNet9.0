using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Basket.API.Features.Basket.Helpers;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.Delete
{
	public class DeleteBasketItemCommandHandler(IDistributedCache cache,IIdentityService identityService,BasketHelper basketHelper) : IRequestHandler<DeleteBasketItemCommand, ServiceResponse>
	{
		public async Task<ServiceResponse> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
		{
			var userId = identityService.UserId;
			var basketData = await basketHelper.GetBasketFromCacheAsync(cancellationToken);
			if (string.IsNullOrEmpty(basketData))
			{
				ServiceResponse.ErrorAsNotFound();
			}
			var basket = JsonSerializer.Deserialize<Data.Basket>(basketData);
			var itemToRemove = basket.BasketItems.FirstOrDefault(i => i.CourseId == request.courseId);
			if (itemToRemove == null)
			{
				ServiceResponse.ErrorAsNotFound();
			}
			basket.BasketItems.Remove(itemToRemove);
			await basketHelper.SetBasketCacheAsync(basket, cancellationToken);
			return ServiceResponse.SuccessAsNoContent();
		}	 
	}
	public record DeleteBasketItemCommand(Guid courseId) : IRequestByServiceResponse;	
}
