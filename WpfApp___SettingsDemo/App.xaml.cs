using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;
using WpfApp___SettingsDemo.Services;

namespace WpfApp___SettingsDemo;

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
        SettingService settingFileSaveService = new SettingService();
        var settingFiles = FetchSettingFileClasses();
        foreach (var item in settingFiles)
        {
            settingFileSaveService.ReadSettingFileOrCreate(item.Value, item.Key);
        }
        //settingFileSaveService.ReadSettingFileOrCreate("", typeof(Setting4));//无无参构造就报错
        services.AddSingleton<ISettingService>(settingFileSaveService);
        services.AddSingleton<MainViewModel>();
        return services.BuildServiceProvider();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        var service = Services.GetService<ISettingService>();
        service!.SaveAllSetting();
        base.OnExit(e);
    }

    public static Dictionary<Type, string> FetchSettingFileClasses()
    {
        Dictionary<Type, string> settingFileClasses = new Dictionary<Type, string>();

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            // 遍历每个程序集的所有类型
            foreach (var type in assembly.GetTypes())
            {
                //无无参构造的过滤
                if (type.GetConstructor(Type.EmptyTypes) == null)
                    continue;
                // 检查类型是否标记了 SettingFileAttribute
                var settingFileAttribute = type.GetCustomAttributes(typeof(SettingFileAttribute), true).FirstOrDefault();
                if (settingFileAttribute is not SettingFileAttribute setting)
                    continue;
                string path;
                if (setting.IsRelativePath)
                {
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, setting.Path);
                }
                else
                {
                    path = setting.Path;
                }
                settingFileClasses[type] = path;
            }
        }
        return settingFileClasses;
    }
}