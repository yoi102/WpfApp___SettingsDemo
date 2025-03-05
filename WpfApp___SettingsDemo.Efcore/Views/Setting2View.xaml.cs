using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfApp___SettingsDemo.Efcore.ViewModels;

namespace WpfApp___SettingsDemo.Efcore.Views;

/// <summary>
/// Setting2View.xaml 的交互逻辑
/// </summary>
public partial class Setting2View 
{
    public Setting2View()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetService<Setting2ViewModel>();

    }
}
