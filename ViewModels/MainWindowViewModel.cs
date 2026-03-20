using System.ComponentModel;

namespace LR_1_Default.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}