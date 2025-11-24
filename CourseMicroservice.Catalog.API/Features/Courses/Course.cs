using CourseMicroservice.Catalog.API.Features.Categories;
using CourseMicroservice.Catalog.API.Repositories;

namespace CourseMicroservice.Catalog.API.Features.Courses
{
	public class Course : BaseEntity
	{
		public string Name { get; set; } = default!;
		public string Description { get; set; } = default!;
		public decimal Price { get; set; }
		public Guid UserId { get; set; }
		public string? Picture { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CategoryId { get; set; } = default!;
		public Category Category { get; set; } = default!;
		public Feature Feature { get; set; } = default!;
	}
}
