using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_CheckBox.Pages;

namespace WPF_CheckBox;

/// <summary>
/// MainWindow.xaml 的交互逻辑
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // 默认显示基本用法页面
        MainContent.Navigate(new BasicUsagePage());
    }

    private void BasicUsage_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Navigate(new BasicUsagePage());
    }

    private void ThreeState_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Navigate(new ThreeStatePage());
    }

    private void CustomContent_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Navigate(new CustomContentPage());
    }

    private void DataBinding_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Navigate(new DataBindingPage());
    }

    private void Styles_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Navigate(new StylesPage());
    }

    private void SettingsScene_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Navigate(new SettingsScenePage());
    }

    private void PermissionsScene_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Navigate(new PermissionsScenePage());
    }

    private void FilterScene_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Navigate(new FilterScenePage());
    }

    private void BestPractices_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Navigate(new BestPracticesPage());
    }
}