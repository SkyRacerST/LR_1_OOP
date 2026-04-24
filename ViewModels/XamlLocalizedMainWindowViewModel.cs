using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using LR_1_Default.Services;

namespace LR_1_Default.ViewModels
{
    public class XamlLocalizedMainWindowViewModel : INotifyPropertyChanged
    {
        private string _selectedLanguage;

        public DefaultBindingViewModel DefaultBindingVM { get; set; }
        public TwoWayBindingViewModel TwoWayBindingVM { get; set; }
        public OneTimeBindingViewModel OneTimeBindingVM { get; set; }
        public OneWayBindingViewModel OneWayBindingVM { get; set; }
        public TriggersViewModel TriggersVM { get; set; }

        public ObservableCollection<string> AvailableLanguages { get; set; }

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (value != null)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged(nameof(SelectedLanguage));

                    var culture = value == "Русский" ? "ru" : "en";
                    XamlLocalizationService.Instance.SetLanguage(culture);
                }
            }
        }

        public XamlLocalizedMainWindowViewModel()
        {
            DefaultBindingVM = new DefaultBindingViewModel();
            TwoWayBindingVM = new TwoWayBindingViewModel();
            OneTimeBindingVM = new OneTimeBindingViewModel();
            OneWayBindingVM = new OneWayBindingViewModel();
            TriggersVM = new TriggersViewModel();

            AvailableLanguages = new ObservableCollection<string>
            {
                "Русский",
                "English"
            };

            _selectedLanguage = "Русский";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}