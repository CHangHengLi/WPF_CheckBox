using System.Windows;
using System.Windows.Controls;

namespace WPF_CheckBox.Pages
{
    public partial class DataBindingPage : Page
    {
        public DataBindingPage()
        {
            InitializeComponent();
        }

        private void AdvancedFeature_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (advancedPanel != null)
            {
                bool isChecked = advancedFeatureCheckBox.IsChecked ?? false;
                advancedPanel.Visibility = isChecked ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
} 