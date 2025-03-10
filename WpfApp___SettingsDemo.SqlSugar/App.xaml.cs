using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Security.Principal;
using System.Windows;
using WpfApp___SettingsDemo.Efcore.ViewModels;
using WpfApp___SettingsDemo.SqlSugar.Services;
using WpfApp___SettingsDemo.SqlSugar.ViewModels;

namespace WpfApp___SettingsDemo.SqlSugar;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    public App()
    {
        Services = ConfigureServices();
        this.InitializeComponent();
    }

    /// <summary>
    /// Gets the current <see cref="App"/> instance in use
    /// </summary>
    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        WindowsIdentity identity = WindowsIdentity.GetCurrent();

        services.AddSingleton<Setting1ViewModel>();
        services.AddSingleton<Setting2ViewModel>();
        services.AddSingleton<ISettingService, SettingService>();

  
        return services.BuildServiceProvider();
    }




}

