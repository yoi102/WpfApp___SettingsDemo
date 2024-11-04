using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace WpfApp___SettingsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<MainViewModel>();

        }
    }
}