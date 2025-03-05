using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfApp___SettingsDemo.Efcore.ViewModels;

namespace WpfApp___SettingsDemo.Efcore.Views;

/// <summary>
/// Setting1View.xaml 的交互逻辑
/// </summary>
public partial class Setting1View 
{
    public Setting1View()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetService<Setting1ViewModel>();
    }
}
