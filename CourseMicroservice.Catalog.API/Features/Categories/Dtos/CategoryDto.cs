namespace CourseMicroservice.Catalog.API.Features.Categories.Dtos
{
	public record class CategoryDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}
