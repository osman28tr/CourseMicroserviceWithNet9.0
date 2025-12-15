using CourseMicroservice.Catalog.API.Features.Courses.Commands.Create;
using CourseMicroservice.Catalog.API.Features.Courses.Commands.Update;
using CourseMicroservice.Catalog.API.Features.Courses.Dtos;

namespace CourseMicroservice.Catalog.API.Features.Courses.Profiles
{
	public class CourseMappingProfile : Profile
	{
		public CourseMappingProfile()
		{
			CreateMap<CreateCourseCommand, Course>().ReverseMap()
				.ForMember(x => x.PictureUrl, opt => opt.MapFrom(x => x.Picture));

			CreateMap<Course, CourseDto>().ReverseMap();
			CreateMap<Course, UpdateCourseCommand>().ReverseMap();
		}
	}
}
