using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands
{
	public class AddBasketItemCommandHandler(IDistributedCache cache) : IRequestHandler<AddBasketItemCommand, ServiceResponse<AddBasketItemCommand>>
	{
		public async Task<ServiceResponse<AddBasketItemCommand>> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
		{
			//basket : userId
			Guid userId = Guid.NewGuid();
			var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

			var hasBasket = await cache.GetStringAsync(cacheKey, cancellationToken);

			BasketDto? basketDto;

			if(!string.IsNullOrEmpty(hasBasket))
			{
				basketDto = JsonSerializer.Deserialize<BasketDto>(hasBasket);
				var existingBasketItem = basketDto?.basketItemDto.FirstOrDefault(bi => bi.CourseId == request.CourseId);

				if (existingBasketItem != null)				
					basketDto?.basketItemDto.Remove(existingBasketItem);					
				
				var basketItemDto = new BasketItemDto(request.CourseId, request.CourseName, request.CoursePrice, request.CourseImageUrl, null);
				basketDto?.basketItemDto.Add(basketItemDto);
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
