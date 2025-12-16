using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Shared.Extensions
{
	public static class VersionExtension
	{
		public static IServiceCollection AddVersioning(this IServiceCollection services)
		{
			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = new ApiVersion(1,0);
				options.AssumeDefaultVersionWhenUnspecified = true; // versiyonlama belirtilmemişse varsayılan versiyonu kullan
				options.ReportApiVersions = true; // desteklenen ve desteklenmeyen versiyonları yanıt başlıklarında bildir
				options.ApiVersionReader = new UrlSegmentApiVersionReader(); // versiyon bilgisini URL segmentinden oku
			})
			//swagger konfigürasyonu
			.AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV"; // Versiyon gruplama formatı
				options.SubstituteApiVersionInUrl = true; // URL'de versiyon bilgisini değiştir
			});
			return services;
		}

		public static ApiVersionSet AddVersionSetExt(this WebApplication app)
		{
			var apiVersionSet = app.NewApiVersionSet()
				.HasApiVersion(new ApiVersion(1, 0))
				.HasApiVersion(new ApiVersion(1, 2))
				.HasApiVersion(new ApiVersion(2, 0))
				.Build();
			return apiVersionSet;
		}
	}
}
