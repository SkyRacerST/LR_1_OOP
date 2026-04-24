using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using LR_1_Default.Services;

namespace LR_1_Default.ViewModels
{
    public class LocalizedMainWindowViewModel : INotifyPropertyChanged
    {
        private readonly LocalizationService _localizationService;
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
                    _localizationService.SetLanguage(value.Name);
                }
            }
        }

        public LocalizedMainWindowViewModel()
        {
            _localizationService = LocalizationService.Instance;

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

            // Устанавливаем русский по умолчанию
            _selectedLanguage = AvailableLanguages.FirstOrDefault(c => c.Name == "ru-RU");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}