using AutoMapper;
using CourseMicroservice.Catalog.API.Features.Categories.Create;
using CourseMicroservice.Catalog.API.Features.Categories.Dtos;
using CourseMicroservice.Catalog.API.Repositories;
using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using CourseMicroservice.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CourseMicroservice.Shared.Responses.ServiceResponse;

namespace CourseMicroservice.Catalog.API.Features.Categories.GetAll
{
	public class GetAllCategoryQuery : IRequestByServiceResponse<List<CategoryDto>>;

	public class GetAllCategoryQueryHandler(AppDbContext context,IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResponse<List<CategoryDto>>>
	{
		public async Task<ServiceResponse<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
		{
			var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);

			var mappedCategories = mapper.Map<List<CategoryDto>>(categories);

			return ServiceResponse<List<CategoryDto>>.SuccessAsOk(mappedCategories);
		}
	}

	public static class GetAllCategoryEndpoint
	{
		public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder.MapGet("/",
				async (IMediator mediator) =>
					(await mediator.Send(new GetAllCategoryQuery())).ToGenericResult());
			return routeGroupBuilder;
		}
	}
}
