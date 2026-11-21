using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace WeatherStation.Tests;

public class MainWindowTests
{
    [WpfFact]
    public void ApplicationHostResolvesMainWindowWithLoadedContent()
    {
        using var host = WeatherStation.Program.CreateHost([]);
        var window = host.Services.GetRequiredService<MainWindow>();
        try
        {
            Assert.IsAssignableFrom<FrameworkElement>(window.Content);
        }
        finally
        {
            window.Close();
        }
    }
}
