using CourseMicroservice.Catalog.API.Features.Courses.Create;

namespace CourseMicroservice.Catalog.API.Features.Courses.Profiles
{
	public class CourseMappingProfile : Profile
	{
		public CourseMappingProfile()
		{
			CreateMap<CreateCourseCommand, Course>().ReverseMap()
				.ForMember(x => x.PictureUrl, opt => opt.MapFrom(x => x.Picture));
		}
	}
}
