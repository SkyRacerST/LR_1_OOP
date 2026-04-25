using System.ComponentModel;
using LocalizationLibrary;

namespace LR_1_Default.ViewModels
{
    public class DefaultBindingViewModel : INotifyPropertyChanged
    {
        private string _userInput;
        private int _sliderValue;

        public string UserInput
        {
            get => _userInput;
            set
            {
                _userInput = value;
                OnPropertyChanged(nameof(UserInput));
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public string DisplayText => _userInput;

        public int SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                OnPropertyChanged(nameof(SliderValue));
                OnPropertyChanged(nameof(SliderValueDisplay));
            }
        }

        public string SliderValueDisplay => $"{LocalizationManager.Instance["SliderValue"]}: {SliderValue}";

        public DefaultBindingViewModel()
        {
            _userInput = LocalizationManager.Instance["DefaultInputText"];
            _sliderValue = 50;

            LocalizationManager.Instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Item[]")
                {
                    // ѕринудительно обновл€ем значение из ресурсов
                    UserInput = LocalizationManager.Instance["DefaultInputText"];
                    OnPropertyChanged(nameof(SliderValueDisplay));
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}