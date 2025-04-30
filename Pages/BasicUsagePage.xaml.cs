using System.Windows;
using System.Windows.Controls;

namespace WPF_CheckBox.Pages
{
    public partial class BasicUsagePage : Page
    {
        public BasicUsagePage()
        {
            InitializeComponent();
        }

        private void EventCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (eventResult != null)
            {
                eventResult.Text = "复选框已选中！当前状态: Checked";
            }
        }

        private void EventCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (eventResult != null)
            {
                eventResult.Text = "复选框已取消选中！当前状态: Unchecked";
            }
        }
    }
} 