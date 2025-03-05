using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp___SettingsDemo.Efcore.Services;

namespace WpfApp___SettingsDemo.Efcore.ViewModels;

internal partial class Setting1ViewModel : ObservableObject
{
    private readonly AppDbContext appDbContext;
    private readonly ISettingService settingService;

    public Setting1ViewModel(AppDbContext appDbContext, ISettingService settingService)
    {
        this.appDbContext = appDbContext;
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
    private async Task SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }


}
