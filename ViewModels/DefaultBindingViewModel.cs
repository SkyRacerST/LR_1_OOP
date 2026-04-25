using System.ComponentModel;
using LocalizationLibrary;

namespace LR_1_Default.ViewModels
{
    public class DefaultBindingViewModel : INotifyPropertyChanged
    {
        private string _userInput;
        private int _sliderValue;
        private bool _isUserModified;

        public string UserInput
        {
            get => _userInput;
            set
            {
                _userInput = value;
                _isUserModified = true;
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
            _isUserModified = false;
            _userInput = LocalizationManager.Instance["DefaultInputText"];
            _sliderValue = 50;

            LocalizationManager.Instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Item[]")
                {
                    if (!_isUserModified)
                    {
                        _userInput = LocalizationManager.Instance["DefaultInputText"];
                        OnPropertyChanged(nameof(UserInput));
                        OnPropertyChanged(nameof(DisplayText));
                    }
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