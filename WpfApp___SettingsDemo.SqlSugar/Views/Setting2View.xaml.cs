using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp___SettingsDemo.Efcore.ViewModels;

namespace WpfApp___SettingsDemo.SqlSugar.Views
{
    /// <summary>
    /// Setting2View.xaml 的交互逻辑
    /// </summary>
    public partial class Setting2View : UserControl
    {
        public Setting2View()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<Setting2ViewModel>();
        }
    }
}
