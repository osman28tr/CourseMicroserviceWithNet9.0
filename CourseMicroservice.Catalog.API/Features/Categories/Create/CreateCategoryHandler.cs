using CourseMicroservice.Catalog.API.Repositories;
using CourseMicroservice.Shared.Responses;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CourseMicroservice.Catalog.API.Features.Categories.Create
{
	public class CreateCategoryHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResponse<CreateCategoryResponse>>
	{
		public async Task<ServiceResponse<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var existCategory = await context.Categories.AnyAsync(x => x.Name == request.name); 

			if (existCategory)
			{
				ServiceResponse.Error("Category name already exists", $"The category name `{request.name}` is already exists", HttpStatusCode.BadRequest);
			}

			var category = new Category { Id = NewId.NextSequentialGuid(), Name = request.name };

			await context.Categories.AddAsync(category);

			await context.SaveChangesAsync();

			return ServiceResponse<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), "empty");
		}
	}
}
