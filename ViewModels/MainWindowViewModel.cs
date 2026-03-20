using CommunityToolkit.Mvvm.ComponentModel;
using LR_1_Toolkit.ViewModels;

namespace LR_1_Toolkit.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public DefaultBindingViewModel DefaultBindingVM { get; set; }
        public TwoWayBindingViewModel TwoWayBindingVM { get; set; }
        public OneTimeBindingViewModel OneTimeBindingVM { get; set; }
        public OneWayBindingViewModel OneWayBindingVM { get; set; }
        public TriggersViewModel TriggersVM { get; set; }

        public MainWindowViewModel()
        {
            DefaultBindingVM = new DefaultBindingViewModel();
            TwoWayBindingVM = new TwoWayBindingViewModel();
            OneTimeBindingVM = new OneTimeBindingViewModel();
            OneWayBindingVM = new OneWayBindingViewModel();
            TriggersVM = new TriggersViewModel();
        }
    }
}