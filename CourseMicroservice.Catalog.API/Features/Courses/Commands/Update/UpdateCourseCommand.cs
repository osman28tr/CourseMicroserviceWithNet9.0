using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Catalog.API.Features.Courses.Commands.Update
{
	public class UpdateCourseCommand : IRequestByServiceResponse<UpdateCourseCommand>
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = default!;
		public string Description { get; set; } = default!;
		public decimal Price { get; set; }
		public Guid CategoryId { get; set; }
		public Guid UserId { get; set; }
		public string? Picture { get; set; }
		public Feature Feature { get; set; } = default!;
	}
}
