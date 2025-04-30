using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_CheckBox.Pages
{
    public partial class PermissionsScenePage : Page
    {
        public PermissionsScenePage()
        {
            InitializeComponent();
            UpdateSelectAllState();
            
            // 添加用户复选框事件
            user1.Checked += User_CheckChanged;
            user1.Unchecked += User_CheckChanged;
            user2.Checked += User_CheckChanged;
            user2.Unchecked += User_CheckChanged;
            user3.Checked += User_CheckChanged;
            user3.Unchecked += User_CheckChanged;
            user4.Checked += User_CheckChanged;
            user4.Unchecked += User_CheckChanged;
            user5.Checked += User_CheckChanged;
            user5.Unchecked += User_CheckChanged;
        }

        private void User_CheckChanged(object sender, RoutedEventArgs e)
        {
            UpdateSelectAllState();
        }

        private void UpdateSelectAllState()
        {
            int checkedCount = 0;
            int totalCount = 5;

            if (user1.IsChecked == true) checkedCount++;
            if (user2.IsChecked == true) checkedCount++;
            if (user3.IsChecked == true) checkedCount++;
            if (user4.IsChecked == true) checkedCount++;
            if (user5.IsChecked == true) checkedCount++;

            if (checkedCount == 0)
                selectAllUsers.IsChecked = false;
            else if (checkedCount == totalCount)
                selectAllUsers.IsChecked = true;
            else
                selectAllUsers.IsChecked = null;
        }

        private void SelectAllUsers_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (selectAllUsers.IsChecked == true || selectAllUsers.IsChecked == false)
            {
                bool isChecked = selectAllUsers.IsChecked == true;
                user1.IsChecked = isChecked;
                user2.IsChecked = isChecked;
                user3.IsChecked = isChecked;
                user4.IsChecked = isChecked;
                user5.IsChecked = isChecked;
            }
        }

        private void SaveAdminPermissions_Click(object sender, RoutedEventArgs e)
        {
            string message = "已保存管理员权限设置：\n";
            message += systemSettingsPermission.IsChecked == true ? "- 系统设置访问权限: 已启用\n" : "- 系统设置访问权限: 已禁用\n";
            message += userManagementPermission.IsChecked == true ? "- 用户管理权限: 已启用\n" : "- 用户管理权限: 已禁用\n";
            message += dataBackupPermission.IsChecked == true ? "- 数据备份权限: 已启用\n" : "- 数据备份权限: 已禁用\n";
            message += logAccessPermission.IsChecked == true ? "- 系统日志访问权限: 已启用\n" : "- 系统日志访问权限: 已禁用\n";
            message += auditPermission.IsChecked == true ? "- 审核权限: 已启用" : "- 审核权限: 已禁用";
            
            MessageBox.Show(message, "权限保存", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ApplyPermissions_Click(object sender, RoutedEventArgs e)
        {
            // 获取选中的用户
            string selectedUsers = "";
            if (user1.IsChecked == true) selectedUsers += "用户1, ";
            if (user2.IsChecked == true) selectedUsers += "用户2, ";
            if (user3.IsChecked == true) selectedUsers += "用户3, ";
            if (user4.IsChecked == true) selectedUsers += "用户4, ";
            if (user5.IsChecked == true) selectedUsers += "用户5, ";
            
            if (selectedUsers.Length > 0)
            {
                selectedUsers = selectedUsers.Substring(0, selectedUsers.Length - 2);
                
                // 获取选中的权限
                string selectedPermissions = "";
                if (viewDocumentsPermission.IsChecked == true) selectedPermissions += "查看文档, ";
                if (editDocumentsPermission.IsChecked == true) selectedPermissions += "编辑文档, ";
                if (deleteDocumentsPermission.IsChecked == true) selectedPermissions += "删除文档, ";
                if (shareDocumentsPermission.IsChecked == true) selectedPermissions += "共享文档, ";
                if (addCommentsPermission.IsChecked == true) selectedPermissions += "添加评论, ";
                
                if (selectedPermissions.Length > 0)
                {
                    selectedPermissions = selectedPermissions.Substring(0, selectedPermissions.Length - 2);
                    
                    string message = $"已为以下用户设置权限：\n{selectedUsers}\n\n权限列表：\n{selectedPermissions}";
                    MessageBox.Show(message, "权限应用", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("请至少选择一项权限。", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("请至少选择一个用户。", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void PermissionTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 安全检查
            if (permissionDetailsPanel == null || permissionTemplateComboBox == null)
            {
                return; // 如果控件未初始化，安全退出
            }
            
            permissionDetailsPanel.Children.Clear();
            
            // 安全获取 SelectedIndex
            int selectedIndex = -1;
            if (permissionTemplateComboBox.SelectedIndex >= 0)
            {
                selectedIndex = permissionTemplateComboBox.SelectedIndex;
            }
            
            switch (selectedIndex)
            {
                case 0: // 选择预设模板
                    permissionDetailsPanel.Children.Add(new TextBlock 
                    { 
                        Text = "请选择一个权限模板查看详情", 
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#666")), 
                        Margin = new Thickness(0, 5, 0, 0) 
                    });
                    break;
                    
                case 1: // 只读权限
                    AddPermissionCheckBox("查看文档", true);
                    AddPermissionCheckBox("下载文档", true);
                    AddPermissionCheckBox("编辑文档", false);
                    AddPermissionCheckBox("删除文档", false);
                    AddPermissionCheckBox("共享文档", false);
                    AddPermissionCheckBox("添加评论", false);
                    break;
                    
                case 2: // 标准用户权限
                    AddPermissionCheckBox("查看文档", true);
                    AddPermissionCheckBox("下载文档", true);
                    AddPermissionCheckBox("编辑文档", true);
                    AddPermissionCheckBox("删除文档", false);
                    AddPermissionCheckBox("共享文档", false);
                    AddPermissionCheckBox("添加评论", true);
                    break;
                    
                case 3: // 高级用户权限
                    AddPermissionCheckBox("查看文档", true);
                    AddPermissionCheckBox("下载文档", true);
                    AddPermissionCheckBox("编辑文档", true);
                    AddPermissionCheckBox("删除文档", true);
                    AddPermissionCheckBox("共享文档", true);
                    AddPermissionCheckBox("添加评论", true);
                    AddPermissionCheckBox("管理评论", false);
                    break;
                    
                case 4: // 完全权限
                    AddPermissionCheckBox("查看文档", true);
                    AddPermissionCheckBox("下载文档", true);
                    AddPermissionCheckBox("编辑文档", true);
                    AddPermissionCheckBox("删除文档", true);
                    AddPermissionCheckBox("共享文档", true);
                    AddPermissionCheckBox("添加评论", true);
                    AddPermissionCheckBox("管理评论", true);
                    AddPermissionCheckBox("创建用户", true);
                    AddPermissionCheckBox("管理权限", true);
                    break;
                    
                default:
                    // 处理无效选择
                    permissionDetailsPanel.Children.Add(new TextBlock 
                    { 
                        Text = "无效的模板选择", 
                        Foreground = new SolidColorBrush(Colors.Red), 
                        Margin = new Thickness(0, 5, 0, 0) 
                    });
                    break;
            }
            
            if (selectedIndex > 0)
            {
                Button applyTemplateButton = new Button
                {
                    Content = "应用此模板",
                    Margin = new Thickness(0, 10, 0, 0),
                    Padding = new Thickness(10, 5, 10, 5),
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                applyTemplateButton.Click += ApplyTemplate_Click;
                permissionDetailsPanel.Children.Add(applyTemplateButton);
            }
        }
        
        private void AddPermissionCheckBox(string content, bool isChecked)
        {
            CheckBox checkBox = new CheckBox
            {
                Content = content,
                IsChecked = isChecked,
                Margin = new Thickness(0, 5, 0, 0)
            };
            permissionDetailsPanel.Children.Add(checkBox);
        }
        
        private void ApplyTemplate_Click(object sender, RoutedEventArgs e)
        {
            if (permissionTemplateComboBox.SelectedItem == null)
            {
                MessageBox.Show("请先选择一个模板", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            var selectedItem = permissionTemplateComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null || selectedItem.Content == null)
            {
                MessageBox.Show("模板选择错误", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            string templateName = selectedItem.Content.ToString();
            MessageBox.Show($"已应用 \"{templateName}\" 模板。", "模板应用", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
} 