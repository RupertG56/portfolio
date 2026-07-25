using Portfolio.AdminApp.ViewModel;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Portfolio.AdminApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static IHost Host { get; } =
			Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
				.ConfigureServices(services =>
				{
					services.AddSingleton<MainWindow>();
					services.AddSingleton<MainViewModel>();
				}).Build();

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

}
