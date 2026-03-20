using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LR_1_Toolkit.ViewModels
{
    public partial class OneWayBindingViewModel : ObservableObject
    {
        private string _sourceText = "Введите текст здесь...";
        private int _counter = 0;

        [ObservableProperty]
        private double _sliderValue = 50;

        // Используем полное свойство с вызовом OnPropertyChanged для обновления ProcessedText
        public string SourceText
        {
            get => _sourceText;
            set
            {
                if (SetProperty(ref _sourceText, value))
                {
                    OnPropertyChanged(nameof(ProcessedText));
                }
            }
        }

        // Свойство для счетчика с вызовом OnPropertyChanged для CounterDisplay
        public int Counter
        {
            get => _counter;
            set
            {
                if (SetProperty(ref _counter, value))
                {
                    OnPropertyChanged(nameof(CounterDisplay));
                }
            }
        }

        // Вычисляемое свойство
        public string ProcessedText
        {
            get
            {
                if (string.IsNullOrEmpty(SourceText))
                    return "Обработано: (пусто) | Длина: 0";
                return $"Обработано: {SourceText.ToUpper()} | Длина: {SourceText.Length}";
            }
        }

        public string CounterDisplay => $"Количество кликов: {Counter}";

        public string SliderDisplay => $"Текущее значение: {SliderValue:F0}";

        // Релейные команды
        [RelayCommand]
        private void Increment()
        {
            Counter++;
        }

        [RelayCommand]
        private void Reset()
        {
            Counter = 0;
        }
    }
}