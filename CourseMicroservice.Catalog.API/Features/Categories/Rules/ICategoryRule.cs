namespace CourseMicroservice.Catalog.API.Features.Categories.Rules
{
	public interface ICategoryRule
	{
		Task<bool> IsExistCategory(string name);
	}
}
