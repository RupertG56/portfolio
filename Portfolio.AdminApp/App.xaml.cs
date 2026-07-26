using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.AdminApp.Api;
using Portfolio.AdminApp.Services;
using Portfolio.AdminApp.ViewModel;

namespace Portfolio.AdminApp;

public partial class App : Application
{
    public static IHost Host { get; } =
        Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddHttpClient<IPortfolioApiClient, PortfolioApiClient>(
                    client =>
                    {
                        var baseUrl = context.Configuration["PortfolioApi:BaseUrl"]
                            ?? throw new InvalidOperationException(
                                "PortfolioApi:BaseUrl is not configured.");

                        client.BaseAddress = new Uri(baseUrl);
                    });

                services.AddSingleton<ISiteService, SiteService>();
				services.AddSingleton<SiteViewModel>();
				services.AddSingleton<MainViewModel>();
				services.AddSingleton<MainWindow>();
			})
            .Build();

    protected override async void OnStartup(StartupEventArgs e)
    {
        await Host.StartAsync();

        var window = Host.Services.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await Host.StopAsync();
        Host.Dispose();
        base.OnExit(e);
    }
}
