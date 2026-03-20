using CommunityToolkit.Mvvm.ComponentModel;

namespace LR_1_Toolkit.ViewModels
{
    public partial class DefaultBindingViewModel : ObservableObject
    {
        private string _userInput = "Введите текст...";

        [ObservableProperty]
        private int _sliderValue = 50;

        // Используем полное свойство с вызовом OnPropertyChanged для обновления DisplayText
        public string UserInput
        {
            get => _userInput;
            set
            {
                if (SetProperty(ref _userInput, value))
                {
                    OnPropertyChanged(nameof(DisplayText));
                }
            }
        }

        // Вычисляемое свойство
        public string DisplayText => UserInput;

        public string SliderValueDisplay => $"Значение: {SliderValue}";
    }
}