using DotNet8.Architecture.DbService.AppDbContextModels;
using DotNet8.Modules.Domain.Features.Blog;
using DotNet8.Modules.Infrastructure.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Modules.Presentation.Extensions;

public static class DependencyInjection
{
	private static IServiceCollection AddDbContextServices(this  IServiceCollection services, WebApplicationBuilder builder)
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
		return services.AddDbContextServices(builder)
			.AddRepositoryService();
	}
}
