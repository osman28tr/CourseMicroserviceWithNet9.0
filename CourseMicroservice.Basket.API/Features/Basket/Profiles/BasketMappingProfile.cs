using AutoMapper;
using CourseMicroservice.Basket.API.Data;
using CourseMicroservice.Basket.API.Dtos;

namespace CourseMicroservice.Basket.API.Features.Basket.Profiles
{
	public class BasketMappingProfile : Profile
	{
		public BasketMappingProfile()
		{
			CreateMap<Data.Basket, BasketDto>().ReverseMap();
			CreateMap<BasketItemDto, BasketItem>().ReverseMap();
		}
	}
}
