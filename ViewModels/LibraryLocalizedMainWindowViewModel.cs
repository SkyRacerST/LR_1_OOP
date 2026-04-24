using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using LocalizationLibrary;

namespace LR_1_Default.ViewModels
{
    public class LibraryLocalizedMainWindowViewModel : INotifyPropertyChanged
    {
        private CultureInfo _selectedLanguage;

        public DefaultBindingViewModel DefaultBindingVM { get; set; }
        public TwoWayBindingViewModel TwoWayBindingVM { get; set; }
        public OneTimeBindingViewModel OneTimeBindingVM { get; set; }
        public OneWayBindingViewModel OneWayBindingVM { get; set; }
        public TriggersViewModel TriggersVM { get; set; }

        public ObservableCollection<CultureInfo> AvailableLanguages { get; set; }

        public CultureInfo SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (value != null)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged(nameof(SelectedLanguage));
                    LocalizationManager.Instance.SetLanguage(value.Name);
                }
            }
        }

        public LibraryLocalizedMainWindowViewModel()
        {
            DefaultBindingVM = new DefaultBindingViewModel();
            TwoWayBindingVM = new TwoWayBindingViewModel();
            OneTimeBindingVM = new OneTimeBindingViewModel();
            OneWayBindingVM = new OneWayBindingViewModel();
            TriggersVM = new TriggersViewModel();

            AvailableLanguages = new ObservableCollection<CultureInfo>
            {
                new CultureInfo("ru-RU"),
                new CultureInfo("en-US")
            };

            _selectedLanguage = AvailableLanguages.FirstOrDefault(c => c.Name == "ru-RU");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}