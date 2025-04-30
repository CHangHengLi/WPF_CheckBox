using System.Windows;
using System.Windows.Controls;

namespace WPF_CheckBox.Pages
{
    public partial class ThreeStatePage : Page
    {
        public ThreeStatePage()
        {
            InitializeComponent();
            UpdateStateText();
        }

        private void ThreeState_StateChanged(object sender, RoutedEventArgs e)
        {
            UpdateStateText();
        }

        private void UpdateStateText()
        {
            if (threeStateCheckBox == null || stateText == null) return;

            string stateString;
            if (threeStateCheckBox.IsChecked == true)
                stateString = "选中(IsChecked = true)";
            else if (threeStateCheckBox.IsChecked == false)
                stateString = "未选中(IsChecked = false)";
            else
                stateString = "不确定(IsChecked = null)";

            stateText.Text = $"当前状态：{stateString}";
        }

        private void SetChecked_Click(object sender, RoutedEventArgs e)
        {
            threeStateCheckBox.IsChecked = true;
        }

        private void SetUnchecked_Click(object sender, RoutedEventArgs e)
        {
            threeStateCheckBox.IsChecked = false;
        }

        private void SetIndeterminate_Click(object sender, RoutedEventArgs e)
        {
            threeStateCheckBox.IsChecked = null;
        }

        private void ParentCheckBox_CheckChanged(object sender, RoutedEventArgs e)
        {
            // 避免初始化阶段可能的空引用
            if (childCheckBox1 == null || childCheckBox2 == null || childCheckBox3 == null) return;
            
            // 用户点击了全选按钮，直接切换状态，不考虑中间状态
            bool allChecked = childCheckBox1.IsChecked == true && 
                              childCheckBox2.IsChecked == true && 
                              childCheckBox3.IsChecked == true;
            
            // 如果之前状态是部分选中或全不选，现在变为全选
            // 如果之前状态是全选，现在变为全不选
            bool newState = !allChecked;
            
            // 设置所有子选项为相同的状态
            childCheckBox1.IsChecked = newState;
            childCheckBox2.IsChecked = newState;
            childCheckBox3.IsChecked = newState;
            
            // 确保父选项显示正确的状态
            parentCheckBox.IsChecked = newState;
        }

        private void ChildCheckBox_CheckChanged(object sender, RoutedEventArgs e)
        {
            // 避免初始化阶段可能的空引用
            if (childCheckBox1 == null || childCheckBox2 == null || childCheckBox3 == null) return;
            
            // 更新父CheckBox的状态
            if (childCheckBox1.IsChecked == true && 
                childCheckBox2.IsChecked == true && 
                childCheckBox3.IsChecked == true)
            {
                // 全选
                parentCheckBox.IsChecked = true;
            }
            else if (childCheckBox1.IsChecked == false && 
                    childCheckBox2.IsChecked == false && 
                    childCheckBox3.IsChecked == false)
            {
                // 全不选
                parentCheckBox.IsChecked = false;
            }
            else
            {
                // 部分选中
                parentCheckBox.IsChecked = null;
            }
        }
    }
} 