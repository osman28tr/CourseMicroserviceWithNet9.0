using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Shared.Extensions
{
	public static class SwaggerExt
	{
		public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			return services;
		}

		public static WebApplication AddSwaggerExtension(this WebApplication webApplication)
		{
			if (webApplication.Environment.IsDevelopment())
			{
				//webApplication.MapOpenApi();
				webApplication.UseSwagger();
				webApplication.UseSwaggerUI();
			}
			return webApplication;
		}
	}
}
