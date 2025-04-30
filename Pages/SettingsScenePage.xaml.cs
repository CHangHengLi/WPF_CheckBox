using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_CheckBox.Pages
{
    public partial class SettingsScenePage : Page
    {
        public SettingsScenePage()
        {
            InitializeComponent();
        }

        private void DarkTheme_CheckChanged(object sender, RoutedEventArgs e)
        {
            bool isDarkTheme = darkThemeCheckBox.IsChecked ?? false;
            
            // 简单模拟主题切换效果
            if (isDarkTheme)
            {
                this.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
                this.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                this.Background = new SolidColorBrush(Colors.White);
                this.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void AllNotifications_CheckChanged(object sender, RoutedEventArgs e)
        {
            bool enableNotifications = allNotificationsCheckBox.IsChecked ?? false;
            
            // 确保所有控件都已正确初始化
            if (messageNotificationsCheckBox == null || 
                updateNotificationsCheckBox == null || 
                systemNotificationsCheckBox == null || 
                notificationSoundCheckBox == null)
            {
                return; // 如果任何控件为空，则安全退出
            }
            
            // 虽然已经通过绑定控制了启用状态，但在这里可以添加额外的逻辑
            if (!enableNotifications)
            {
                // 如果关闭了所有通知，可以做一些额外的事情
                messageNotificationsCheckBox.IsChecked = false;
                updateNotificationsCheckBox.IsChecked = false;
                systemNotificationsCheckBox.IsChecked = false;
                notificationSoundCheckBox.IsChecked = false;
            }
            else
            {
                // 恢复默认值
                messageNotificationsCheckBox.IsChecked = true;
                updateNotificationsCheckBox.IsChecked = true;
                systemNotificationsCheckBox.IsChecked = true;
                notificationSoundCheckBox.IsChecked = true;
            }
        }

        private void ResetDefaults_Click(object sender, RoutedEventArgs e)
        {
            // 恢复默认设置
            autoStartCheckBox.IsChecked = false;
            autoUpdateCheckBox.IsChecked = true;
            runInBackgroundCheckBox.IsChecked = false;
            minimizeToTrayCheckBox.IsChecked = false;
            showWelcomeCheckBox.IsChecked = true;
            restoreSessionCheckBox.IsChecked = false;
            
            showStatusBarCheckBox.IsChecked = true;
            showToolbarCheckBox.IsChecked = true;
            darkThemeCheckBox.IsChecked = false;
            showPreviewCheckBox.IsChecked = false;
            
            autoSaveCheckBox.IsChecked = false;
            save10MinCheckBox.IsChecked = true;
            saveBackgroundCheckBox.IsChecked = false;
            createBackupCheckBox.IsChecked = false;
            spellCheckCheckBox.IsChecked = true;
            autoCompleteCheckBox.IsChecked = true;
            
            allNotificationsCheckBox.IsChecked = true;
            messageNotificationsCheckBox.IsChecked = true;
            updateNotificationsCheckBox.IsChecked = true;
            systemNotificationsCheckBox.IsChecked = true;
            notificationSoundCheckBox.IsChecked = true;
            
            MessageBox.Show("设置已恢复为默认值。", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            // 模拟保存设置
            MessageBox.Show("设置已保存。", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
} 