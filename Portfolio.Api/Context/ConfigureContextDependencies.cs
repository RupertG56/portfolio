using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Portfolio.Api.Common;

namespace Portfolio.Api.Context;

public static class ConfigureContextDependencies
{
    public static void AddConfiguredContextDependencies(this IHostApplicationBuilder builder)
    {
		builder.Services.Configure<ProviderOptions>(
			builder.Configuration.GetSection(ProviderOptions.SectionName));
		builder.Services.AddSingleton<IMongoClient>(sp =>
		{
			var options = sp.GetRequiredService<IOptions<ProviderOptions>>().Value;
			return new MongoClient(options.ConnectionString);
		});
		builder.Services.AddSingleton<IPortfolioContext, PortfolioContext>();
    }
}
