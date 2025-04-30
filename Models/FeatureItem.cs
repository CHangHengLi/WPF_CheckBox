using WPF_CheckBox.ViewModels;

namespace WPF_CheckBox.Models
{
    public class FeatureItem : ViewModelBase
    {
        private string _name = "";
        private bool _isEnabled;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public FeatureItem(string name, bool isEnabled = false)
        {
            _name = name;
            _isEnabled = isEnabled;
        }
    }
} 