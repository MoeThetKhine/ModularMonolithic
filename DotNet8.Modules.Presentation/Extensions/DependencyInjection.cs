namespace DotNet8.Modules.Presentation.Extensions;

public static class DependencyInjection
{
	#region AddDbContextServices

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

	#endregion

	#region AddRepositoryService

	private static IServiceCollection AddRepositoryService(this IServiceCollection services)
	{
		return services.AddScoped<IBlogRepository, BlogRepository>();
	}

	#endregion

	#region AddDependencyInjection

	public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
	{
		return services.AddDbContextServices(builder)
			.AddRepositoryService();
	}

	#endregion
}
