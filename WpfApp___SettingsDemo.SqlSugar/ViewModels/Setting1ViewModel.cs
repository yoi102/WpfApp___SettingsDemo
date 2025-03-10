using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp___SettingsDemo.SqlSugar.Services;

namespace WpfApp___SettingsDemo.SqlSugar.ViewModels;

internal partial class Setting1ViewModel : ObservableObject
{
    private readonly ISettingService settingService;

    public Setting1ViewModel(ISettingService settingService)
    {
        this.settingService = settingService;
    }

    public int MyProperty
    {
        get { return settingService.UserSettings.Setting1.Setting1_Property; }
        set
        {
            settingService.UserSettings.Setting1.Setting1_Property = value;
            OnPropertyChanged();
        }
    }

    [RelayCommand]
    private void Save()
    {
        settingService.Save();
    }
}