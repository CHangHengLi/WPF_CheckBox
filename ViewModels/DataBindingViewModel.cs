using System.Collections.ObjectModel;
using WPF_CheckBox.Models;

namespace WPF_CheckBox.ViewModels
{
    public class DataBindingViewModel : ViewModelBase
    {
        private bool _receiveNewsletter;
        public bool ReceiveNewsletter
        {
            get => _receiveNewsletter;
            set => SetProperty(ref _receiveNewsletter, value);
        }

        private ObservableCollection<FeatureItem> _featureList = new();
        public ObservableCollection<FeatureItem> FeatureList
        {
            get => _featureList;
            set => SetProperty(ref _featureList, value);
        }

        public DataBindingViewModel()
        {
            // 初始化特性列表
            FeatureList.Add(new FeatureItem("自动保存", true));
            FeatureList.Add(new FeatureItem("云同步"));
            FeatureList.Add(new FeatureItem("开发者模式"));
            FeatureList.Add(new FeatureItem("自动更新", true));
            FeatureList.Add(new FeatureItem("数据加密"));
        }
    }
} 