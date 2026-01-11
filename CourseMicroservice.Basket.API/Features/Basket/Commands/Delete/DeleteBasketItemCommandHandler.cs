using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.Delete
{
	public class DeleteBasketItemCommandHandler(IDistributedCache cache,IIdentityService identityService) : IRequestHandler<DeleteBasketItemCommand, ServiceResponse>
	{
		public async Task<ServiceResponse> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
		{
			var userId = identityService.UserId;
			var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);
			var basketData = await cache.GetStringAsync(cacheKey, cancellationToken);
			if (string.IsNullOrEmpty(basketData))
			{
				ServiceResponse.ErrorAsNotFound();
			}
			var basket = JsonSerializer.Deserialize<BasketDto>(basketData);
			var itemToRemove = basket.BasketItems.FirstOrDefault(i => i.CourseId == request.courseId);
			if (itemToRemove == null)
			{
				ServiceResponse.ErrorAsNotFound();
			}
			basket.BasketItems.Remove(itemToRemove);
			var updatedBasketData = JsonSerializer.Serialize(basket);
			await cache.SetStringAsync(cacheKey, updatedBasketData, cancellationToken);
			return ServiceResponse.SuccessAsNoContent();
		}	 
	}
	public record DeleteBasketItemCommand(Guid courseId) : IRequestByServiceResponse;	
}
