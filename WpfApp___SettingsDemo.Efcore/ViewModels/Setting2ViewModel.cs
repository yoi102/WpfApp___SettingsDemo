using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using WpfApp___SettingsDemo.Efcore.Services;

namespace WpfApp___SettingsDemo.Efcore.ViewModels;

internal partial class Setting2ViewModel : ObservableObject
{
    private readonly ISettingService settingService;

    public Setting2ViewModel(ISettingService settingService)
    {
        this.settingService = settingService;
    }

    public string MyProperty
    {
        get { return settingService.UserSettings.Setting2.Setting2_Property; }
        set
        {
            settingService.UserSettings.Setting2.Setting2_Property = value;

            OnPropertyChanged();
        }
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await settingService.SaveAsync();
    }
}