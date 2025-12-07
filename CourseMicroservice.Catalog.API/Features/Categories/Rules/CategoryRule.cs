using CourseMicroservice.Catalog.API.Repositories;
using CourseMicroservice.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CourseMicroservice.Catalog.API.Features.Categories.Rules
{
	public class CategoryRule : ICategoryRule
	{
		private readonly AppDbContext _context;
		public CategoryRule(AppDbContext context)
		{
			_context = context;
		}
		public async Task<bool> IsExistCategory(string name)
		{
			var existCategory = await _context.Categories.AnyAsync(x => x.Name == name);

			if (existCategory)
			{
				return false;
			}
			return true;
		}
	}
}
