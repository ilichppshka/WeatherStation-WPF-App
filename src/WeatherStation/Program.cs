using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WeatherStation;

internal static class Program
{
    [STAThread]
    public static int Main(string[] args)
    {
        using var host = CreateHost(args);
        host.Start();
        try
        {
            var app = new App();
            app.InitializeComponent();
            return app.Run(host.Services.GetRequiredService<MainWindow>());
        }
        finally
        {
            host.StopAsync().GetAwaiter().GetResult();
        }
    }

    internal static IHost CreateHost(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddSingleton<MainWindow>();
        return builder.Build();
    }
}
