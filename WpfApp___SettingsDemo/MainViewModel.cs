using WpfApp___SettingsDemo.Services;
using WpfApp___SettingsDemo.Settings;

namespace WpfApp___SettingsDemo
{
    internal class MainViewModel
    {
        private readonly Setting1 setting1;
        private readonly Setting2 setting2;
        private readonly Setting3 setting3;
        private readonly ISettingService settingFileSaveService;

        public MainViewModel(ISettingService settingFileSaveService)
        {
            this.setting1 = settingFileSaveService.GetSetting<Setting1>();
            this.setting2 = settingFileSaveService.GetSetting<Setting2>();
            this.setting3 = settingFileSaveService.GetSetting<Setting3>();
            //var test = settingFileSaveService.GetSetting<Setting4>();//没注册的，会报错的
            this.settingFileSaveService = settingFileSaveService;
        }





    }
}
