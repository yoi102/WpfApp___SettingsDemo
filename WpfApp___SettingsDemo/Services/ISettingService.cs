namespace WpfApp___SettingsDemo.Services
{
    internal interface ISettingService
    {
        TSettingType GetSetting<TSettingType>() where TSettingType : class;
        void SaveSettings<TSettingType>() where TSettingType : class;
        void SaveAllSetting();

    }
}
