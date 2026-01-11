using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.Create
{
	public class AddBasketItemCommandHandler(IDistributedCache cache,IIdentityService identityService) : IRequestHandler<AddBasketItemCommand, ServiceResponse<AddBasketItemCommand>>
	{
		public async Task<ServiceResponse<AddBasketItemCommand>> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
		{
			//basket : userId
			Guid userId = identityService.UserId;
			var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

			var hasBasket = await cache.GetStringAsync(cacheKey, cancellationToken);

			BasketDto? basketDto;

			if(!string.IsNullOrEmpty(hasBasket))
			{
				basketDto = JsonSerializer.Deserialize<BasketDto>(hasBasket);
				var existingBasketItem = basketDto?.BasketItems.FirstOrDefault(bi => bi.CourseId == request.CourseId);

				if (existingBasketItem != null)				
					basketDto?.BasketItems.Remove(existingBasketItem);					
				
				var basketItemDto = new BasketItemDto(request.CourseId, request.CourseName, request.CoursePrice, request.CourseImageUrl, null);
				basketDto?.BasketItems.Add(basketItemDto);
			}
			else
			{
				var basketItemDto = new BasketItemDto(request.CourseId, request.CourseName, request.CoursePrice, request.CourseImageUrl, null);
				basketDto = new BasketDto(userId, [basketItemDto]);
			}

			var basketJsonString = JsonSerializer.Serialize(basketDto);

			await cache.SetStringAsync(cacheKey, basketJsonString, cancellationToken);

			return ServiceResponse<AddBasketItemCommand>.SuccessAsCreated(request, "");
		}
	}
}
