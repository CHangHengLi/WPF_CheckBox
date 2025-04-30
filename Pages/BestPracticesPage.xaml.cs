using System.Windows;
using System.Windows.Controls;

namespace WPF_CheckBox.Pages
{
    public partial class BestPracticesPage : Page
    {
        public BestPracticesPage()
        {
            InitializeComponent();
        }

        private void EnableAdvancedSettings_CheckChanged(object sender, RoutedEventArgs e)
        {
            bool isChecked = enableAdvancedSettings.IsChecked ?? false;
            advancedSettingsPanel.Visibility = isChecked ? Visibility.Visible : Visibility.Collapsed;
        }
    }
} 