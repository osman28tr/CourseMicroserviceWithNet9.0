using AutoMapper;
using CourseMicroservice.Catalog.API.Features.Categories.Dtos;
using CourseMicroservice.Catalog.API.Features.Categories.GetAll;
using CourseMicroservice.Catalog.API.Repositories;
using CourseMicroservice.Shared.Responses;
using CourseMicroservice.Shared.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Catalog.API.Features.Categories.GetById
{
	public static class GetByIdCategoryEndpoint
	{
		public record class GetByIdCategoryQuery(Guid id) : IRequestByServiceResponse<CategoryDto>;

		public class GetByIdCategoryQueryHandler(AppDbContext context,IMapper mapper) : IRequestHandler<GetByIdCategoryQuery, ServiceResponse<CategoryDto>>
		{
			public async Task<ServiceResponse<CategoryDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
			{
				var category = await context.Categories.FindAsync(request.id, cancellationToken);
				if(category is null)
				{
					return ServiceResponse<CategoryDto>.Error("Category not found", $"The category with Id {request.id} was not found", HttpStatusCode.NotFound);
				}
				var mappedCategory = mapper.Map<CategoryDto>(category);
				return ServiceResponse<CategoryDto>.SuccessAsOk(mappedCategory);
			}
		}
		public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapGet("/{id:guid}",
				async (IMediator mediator, Guid id) =>
					(await mediator.Send(new GetByIdCategoryQuery(id))).ToGenericResult());
			return routeGroupBuilder;
		}

	}
}
