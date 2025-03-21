using DotNet8.Architecture.DbService.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Modules.Presentation.Extensions
{
	public static class DependencyInjection
	{
		private static IServiceCollection AddDbContextSerices(this  IServiceCollection services, WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<AppDbContext>(
			opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
				opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			},
			ServiceLifetime.Transient,
			ServiceLifetime.Transient
			);

			return services;
		}

		private static IServiceCollection AddRepositoryService(this IServiceCollection services)
		{
			return services.AddScoped<IBlogRepository, BlogRepository>();
		}

		public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
		{
			return services.AddDbContextService(builder)
				.AddRepositoryService();
		}
	}

}
