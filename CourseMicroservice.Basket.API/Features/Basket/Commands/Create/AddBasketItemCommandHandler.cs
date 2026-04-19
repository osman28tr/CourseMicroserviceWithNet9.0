using CourseMicroservice.Basket.API.Consts;
using CourseMicroservice.Basket.API.Data;
using CourseMicroservice.Basket.API.Dtos;
using CourseMicroservice.Basket.API.Features.Basket.Helpers;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseMicroservice.Basket.API.Features.Basket.Commands.Create
{
	public class AddBasketItemCommandHandler(IDistributedCache cache,IIdentityService identityService,BasketHelper basketHelper) : IRequestHandler<AddBasketItemCommand, ServiceResponse<AddBasketItemCommand>>
	{
		public async Task<ServiceResponse<AddBasketItemCommand>> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
		{
			//basket : userId
			Guid userId = identityService.UserId;

			var hasBasket = await basketHelper.GetBasketFromCacheAsync(cancellationToken);

			Data.Basket? basket;

			if(!string.IsNullOrEmpty(hasBasket))
			{
				basket = JsonSerializer.Deserialize<Data.Basket>(hasBasket);
				var existingBasketItem = basket?.BasketItems.FirstOrDefault(bi => bi.CourseId == request.CourseId);

				if (existingBasketItem != null)
					basket?.BasketItems.Remove(existingBasketItem);					
				
				var basketItem = new BasketItem(request.CourseId, request.CourseName, request.CoursePrice, request.CourseImageUrl, null);
				basket?.BasketItems.Add(basketItem);
			}
			else
			{
				var basketItem = new BasketItem(request.CourseId, request.CourseName, request.CoursePrice, request.CourseImageUrl, null);
				basket = new Data.Basket(userId, [basketItem]);
			}

			await basketHelper.SetBasketCacheAsync(basket, cancellationToken);

			return ServiceResponse<AddBasketItemCommand>.SuccessAsCreated(request, "");
		}
	}
}
