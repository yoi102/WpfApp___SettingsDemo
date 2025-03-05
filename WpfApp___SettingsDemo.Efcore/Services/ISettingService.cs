namespace WpfApp___SettingsDemo.Efcore.Services;

public interface ISettingService
{
    UserSettings UserSettings { get; }

    Task SaveAsync();
}
