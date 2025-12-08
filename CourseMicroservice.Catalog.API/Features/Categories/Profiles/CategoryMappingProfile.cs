using AutoMapper;
using CourseMicroservice.Catalog.API.Features.Categories.Dtos;

namespace CourseMicroservice.Catalog.API.Features.Categories.Profiles
{
	public class CategoryMappingProfile : Profile
	{
		public CategoryMappingProfile()
		{
			CreateMap<Category, CategoryDto>().ReverseMap();
		}
	}
}
