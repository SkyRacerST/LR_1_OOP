using System.ComponentModel;

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
                OnPropertyChanged(nameof(DisplayText)); // Обновляем DisplayText при изменении UserInput
            }
        }

        // DisplayText теперь просто возвращает UserInput
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

        public string SliderValueDisplay => $"Значение: {SliderValue}";

        public DefaultBindingViewModel()
        {
            _userInput = "Введите текст...";
            _sliderValue = 50;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}