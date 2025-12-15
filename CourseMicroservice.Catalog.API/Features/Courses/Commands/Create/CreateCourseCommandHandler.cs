using CourseMicroservice.Catalog.API.Features.Courses.Rules;
using CourseMicroservice.Shared.Responses;

namespace CourseMicroservice.Catalog.API.Features.Courses.Commands.Create
{
	public class CreateCourseCommandHandler(AppDbContext context,IMapper mapper,ICourseRule courseRule) : IRequestHandler<CreateCourseCommand, ServiceResponse<Guid>>
	{
		public async Task<ServiceResponse<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
		{
			var mappedCourse = mapper.Map<Course>(request);
			mappedCourse.CreatedDate = DateTime.Now;
			mappedCourse.Id = NewId.NextSequentialGuid();
			mappedCourse.Feature = new Feature
			{
				Duration = 10,
				Rating = 0,
				EducatorFullName = "Osman Tonbul"
			};

			var checkRule = await courseRule.IsExistCourseAndCategoryAsync(context, mappedCourse.Name, mappedCourse.CategoryId);

			if (!checkRule.IsSuccess)
			{
				return checkRule;
			}

			await context.Courses.AddAsync(mappedCourse);
			await context.SaveChangesAsync(cancellationToken);

			return ServiceResponse<Guid>.SuccessAsCreated(mappedCourse.Id, $"/api/courses/{mappedCourse.Id}");
		}		
	}
}
