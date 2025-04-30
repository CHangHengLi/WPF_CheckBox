using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF_CheckBox.Models;

namespace WPF_CheckBox.Pages
{
    public partial class FilterScenePage : Page
    {
        private List<Product> allProducts = new List<Product>();
        private List<Product> filteredProducts = new List<Product>();
        private int currentSortingIndex = 0;
        
        public FilterScenePage()
        {
            InitializeComponent();
            CreateSampleProducts();
            
            // 初始加载所有产品
            UpdateProductDisplay(allProducts);
        }
        
        private void CreateSampleProducts()
        {
            // 电子产品
            allProducts.Add(new Product("智能手机", "电子产品", 2999, 5, true, false, true));
            allProducts.Add(new Product("蓝牙耳机", "电子产品", 299, 4, true, true, true));
            allProducts.Add(new Product("平板电脑", "电子产品", 3499, 5, true, false, true));
            allProducts.Add(new Product("智能手表", "电子产品", 1299, 3, true, false, false));
            
            // 家居用品
            allProducts.Add(new Product("沙发靠垫", "家居用品", 89, 4, true, false, false));
            allProducts.Add(new Product("床上四件套", "家居用品", 299, 5, true, true, false));
            allProducts.Add(new Product("装饰画", "家居用品", 149, 4, true, false, true));
            
            // 厨房用具
            allProducts.Add(new Product("不锈钢锅", "厨房用具", 199, 5, true, false, false));
            allProducts.Add(new Product("厨房置物架", "厨房用具", 79, 3, true, true, false));
            allProducts.Add(new Product("电饭煲", "厨房用具", 499, 4, true, false, true));
            
            // 办公用品
            allProducts.Add(new Product("笔记本", "办公用品", 15, 4, true, false, false));
            allProducts.Add(new Product("订书机", "办公用品", 28, 3, true, false, false));
            allProducts.Add(new Product("文件夹", "办公用品", 12, 4, true, true, false));
            
            // 户外装备
            allProducts.Add(new Product("登山背包", "户外装备", 459, 5, true, false, true));
            allProducts.Add(new Product("帐篷", "户外装备", 899, 4, true, false, false));
            allProducts.Add(new Product("防水手电", "户外装备", 89, 3, true, true, false));
        }
        
        private void UpdateProductDisplay(List<Product> products)
        {
            // 添加空值检查
            if (products == null)
            {
                products = new List<Product>();
            }
            
            if (productsPanel == null || noResultsText == null || resultCount == null)
            {
                return; // 如果任何控件为null，则安全退出
            }
            
            productsPanel.Children.Clear();
            
            if (products.Count == 0)
            {
                noResultsText.Visibility = Visibility.Visible;
                resultCount.Text = "显示0个结果";
                return;
            }
            
            noResultsText.Visibility = Visibility.Collapsed;
            resultCount.Text = $"显示{products.Count}个结果";
            
            foreach (var product in products)
            {
                // 创建产品卡片
                Border card = new Border
                {
                    Width = 160,
                    Margin = new Thickness(10),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(221, 221, 221)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(4),
                    Background = new SolidColorBrush(Colors.White)
                };
                
                StackPanel cardContent = new StackPanel
                {
                    Margin = new Thickness(10)
                };
                
                // 产品类别标签
                Border categoryBadge = new Border
                {
                    Background = product.CategoryColor,
                    CornerRadius = new CornerRadius(2),
                    Padding = new Thickness(5, 2, 5, 2),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(0, 0, 0, 8)
                };
                
                categoryBadge.Child = new TextBlock
                {
                    Text = product.Category,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontSize = 10
                };
                
                // 产品名称
                TextBlock nameText = new TextBlock
                {
                    Text = product.Name,
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                
                // 价格
                TextBlock priceText = new TextBlock
                {
                    Text = $"¥{product.Price:N2}",
                    Foreground = new SolidColorBrush(Colors.Red),
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                
                // 评分
                StackPanel ratingPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 0, 0, 8)
                };
                
                for (int i = 0; i < 5; i++)
                {
                    TextBlock star = new TextBlock
                    {
                        Text = "★",
                        FontSize = 14,
                        Foreground = i < product.Rating 
                            ? new SolidColorBrush(Colors.Orange) 
                            : new SolidColorBrush(Color.FromRgb(200, 200, 200))
                    };
                    ratingPanel.Children.Add(star);
                }
                
                // 标签面板
                WrapPanel tagsPanel = new WrapPanel();
                
                if (product.InStock)
                {
                    Border inStockTag = CreateTag("有货", Colors.Green);
                    tagsPanel.Children.Add(inStockTag);
                }
                
                if (product.OnSale)
                {
                    Border onSaleTag = CreateTag("促销", Colors.Red);
                    tagsPanel.Children.Add(onSaleTag);
                }
                
                if (product.FreeShipping)
                {
                    Border freeShippingTag = CreateTag("免运费", Colors.Blue);
                    tagsPanel.Children.Add(freeShippingTag);
                }
                
                // 组装卡片
                cardContent.Children.Add(categoryBadge);
                cardContent.Children.Add(nameText);
                cardContent.Children.Add(priceText);
                cardContent.Children.Add(ratingPanel);
                cardContent.Children.Add(tagsPanel);
                
                card.Child = cardContent;
                productsPanel.Children.Add(card);
            }
        }
        
        private Border CreateTag(string text, Color color)
        {
            Border tag = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(50, color.R, color.G, color.B)),
                BorderBrush = new SolidColorBrush(color),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(2),
                Padding = new Thickness(3, 1, 3, 1),
                Margin = new Thickness(0, 0, 5, 0)
            };
            
            tag.Child = new TextBlock
            {
                Text = text,
                Foreground = new SolidColorBrush(color),
                FontSize = 10
            };
            
            return tag;
        }
        
        private void Filter_Changed(object sender, RoutedEventArgs e)
        {
            // 如果筛选条件发生变化，可以立即更新或等待用户点击应用按钮
            // 这里简单记录筛选条件已改变
        }
        
        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            // 应用筛选条件
            filteredProducts = new List<Product>();
            
            // 从所有产品开始筛选
            foreach (var product in allProducts)
            {
                bool matchesCategory = false;
                bool matchesPrice = false;
                bool matchesRating = false;
                bool matchesOtherOptions = true;
                
                // 检查类别
                bool hasCategoryFilter = electronicsCategory.IsChecked == true || 
                                        homeCategory.IsChecked == true || 
                                        kitchenCategory.IsChecked == true || 
                                        officeCategory.IsChecked == true || 
                                        outdoorCategory.IsChecked == true;
                
                if (!hasCategoryFilter)
                {
                    matchesCategory = true;
                }
                else
                {
                    if ((electronicsCategory.IsChecked == true && product.Category == "电子产品") ||
                        (homeCategory.IsChecked == true && product.Category == "家居用品") ||
                        (kitchenCategory.IsChecked == true && product.Category == "厨房用具") ||
                        (officeCategory.IsChecked == true && product.Category == "办公用品") ||
                        (outdoorCategory.IsChecked == true && product.Category == "户外装备"))
                    {
                        matchesCategory = true;
                    }
                }
                
                // 检查价格
                bool hasPriceFilter = price0to100.IsChecked == true || 
                                     price100to500.IsChecked == true || 
                                     price500to1000.IsChecked == true || 
                                     priceOver1000.IsChecked == true;
                
                if (!hasPriceFilter)
                {
                    matchesPrice = true;
                }
                else
                {
                    if ((price0to100.IsChecked == true && product.Price >= 0 && product.Price <= 100) ||
                        (price100to500.IsChecked == true && product.Price > 100 && product.Price <= 500) ||
                        (price500to1000.IsChecked == true && product.Price > 500 && product.Price <= 1000) ||
                        (priceOver1000.IsChecked == true && product.Price > 1000))
                    {
                        matchesPrice = true;
                    }
                }
                
                // 检查评分
                bool hasRatingFilter = rating5.IsChecked == true || 
                                      rating4.IsChecked == true || 
                                      rating3.IsChecked == true || 
                                      ratingBelow2.IsChecked == true;
                
                if (!hasRatingFilter)
                {
                    matchesRating = true;
                }
                else
                {
                    if ((rating5.IsChecked == true && product.Rating == 5) ||
                        (rating4.IsChecked == true && product.Rating == 4) ||
                        (rating3.IsChecked == true && product.Rating == 3) ||
                        (ratingBelow2.IsChecked == true && product.Rating <= 2))
                    {
                        matchesRating = true;
                    }
                }
                
                // 检查其他选项
                if (inStock.IsChecked == true && !product.InStock)
                {
                    matchesOtherOptions = false;
                }
                
                if (onSale.IsChecked == true && !product.OnSale)
                {
                    matchesOtherOptions = false;
                }
                
                if (freeShipping.IsChecked == true && !product.FreeShipping)
                {
                    matchesOtherOptions = false;
                }
                
                // 添加符合所有条件的产品
                if (matchesCategory && matchesPrice && matchesRating && matchesOtherOptions)
                {
                    filteredProducts.Add(product);
                }
            }
            
            // 应用当前排序
            ApplySorting(filteredProducts);
            
            // 更新显示
            UpdateProductDisplay(filteredProducts);
        }
        
        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            // 重置所有筛选条件
            electronicsCategory.IsChecked = false;
            homeCategory.IsChecked = false;
            kitchenCategory.IsChecked = false;
            officeCategory.IsChecked = false;
            outdoorCategory.IsChecked = false;
            
            price0to100.IsChecked = false;
            price100to500.IsChecked = false;
            price500to1000.IsChecked = false;
            priceOver1000.IsChecked = false;
            
            rating5.IsChecked = false;
            rating4.IsChecked = false;
            rating3.IsChecked = false;
            ratingBelow2.IsChecked = false;
            
            inStock.IsChecked = true;
            onSale.IsChecked = false;
            freeShipping.IsChecked = false;
            
            // 应用当前排序
            ApplySorting(allProducts);
            
            // 显示所有产品
            UpdateProductDisplay(allProducts);
        }
        
        private void SortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentSortingIndex = sortingComboBox.SelectedIndex;
            
            if (filteredProducts.Count > 0)
            {
                // 如果有筛选结果，则对筛选结果排序
                ApplySorting(filteredProducts);
                UpdateProductDisplay(filteredProducts);
            }
            else
            {
                // 否则对所有产品排序
                ApplySorting(allProducts);
                UpdateProductDisplay(allProducts);
            }
        }
        
        private void ApplySorting(List<Product> products)
        {
            switch (currentSortingIndex)
            {
                case 0: // 默认排序 - 按类别
                    products.Sort((p1, p2) => p1.Category.CompareTo(p2.Category));
                    break;
                case 1: // 价格从低到高
                    products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
                    break;
                case 2: // 价格从高到低
                    products.Sort((p1, p2) => p2.Price.CompareTo(p1.Price));
                    break;
                case 3: // 评分从高到低
                    products.Sort((p1, p2) => p2.Rating.CompareTo(p1.Rating));
                    break;
            }
        }
    }
}