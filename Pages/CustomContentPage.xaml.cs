using System.Windows;
using System.Windows.Controls;

namespace WPF_CheckBox.Pages
{
    public partial class CustomContentPage : Page
    {
        public CustomContentPage()
        {
            InitializeComponent();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            // 阻止事件冒泡，防止触发CheckBox的点击事件
            e.Handled = true;
            
            // 切换帮助文本的可见性
            helpText.Visibility = helpText.Visibility == Visibility.Visible 
                ? Visibility.Collapsed 
                : Visibility.Visible;
        }
    }
} 