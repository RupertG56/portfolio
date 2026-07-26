namespace Portfolio.Api.Site;

public static class SiteDependencyRegistration
{
    public static void AddSiteDependencies(this IServiceCollection services)
    {
        services.AddScoped<ISiteRepository, SiteRepository>();
        services.AddScoped<ISiteService, SiteService>();
    }
}
