using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Security.Principal;
using System.Windows;
using WpfApp___SettingsDemo.Efcore.Services;
using WpfApp___SettingsDemo.Efcore.ViewModels;
using static System.Formats.Asn1.AsnWriter;

namespace WpfApp___SettingsDemo.Efcore;
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
        services.AddDbContext<AppDbContext>();

        var serviceProvider = services.BuildServiceProvider();

        // 创建作用域，获取 AppDbContext 实例，然后调用 EnsureCreated()
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            // 如果数据库不存在，则会自动创建
            context.Database.EnsureCreated();
            // ✅ 确保当前用户的设置存在
            context.EnsureUserSettingsExists();
        }

        return serviceProvider;
    }












}

