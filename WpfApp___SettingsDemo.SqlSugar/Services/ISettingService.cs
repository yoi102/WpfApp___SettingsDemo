using WpfApp___SettingsDemo.SqlSugar.Entities;

namespace WpfApp___SettingsDemo.SqlSugar.Services;

public interface ISettingService
{
    UserSettings UserSettings { get; }

    void Save();
}
