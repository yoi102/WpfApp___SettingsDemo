using WpfApp___SettingsDemo.Efcore.Entities;

namespace WpfApp___SettingsDemo.Efcore.Services;

public interface ISettingService
{
    UserSettings UserSettings { get; }

    Task SaveAsync();
}
