using System.Windows.Media;

namespace WPF_CheckBox.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public bool InStock { get; set; }
        public bool OnSale { get; set; }
        public bool FreeShipping { get; set; }
        public string ImagePath { get; set; }
        public Brush CategoryColor { get; set; }

        public Product(string name, string category, decimal price, int rating, 
                      bool inStock = true, bool onSale = false, bool freeShipping = false)
        {
            Name = name;
            Category = category;
            Price = price;
            Rating = rating;
            InStock = inStock;
            OnSale = onSale;
            FreeShipping = freeShipping;
            
            // 根据类别设置颜色
            switch (category)
            {
                case "电子产品":
                    CategoryColor = new SolidColorBrush(Colors.DodgerBlue);
                    break;
                case "家居用品":
                    CategoryColor = new SolidColorBrush(Colors.SeaGreen);
                    break;
                case "厨房用具":
                    CategoryColor = new SolidColorBrush(Colors.Crimson);
                    break;
                case "办公用品":
                    CategoryColor = new SolidColorBrush(Colors.DarkOrange);
                    break;
                case "户外装备":
                    CategoryColor = new SolidColorBrush(Colors.Purple);
                    break;
                default:
                    CategoryColor = new SolidColorBrush(Colors.Gray);
                    break;
            }
        }
    }
} 