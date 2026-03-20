using System.ComponentModel;

namespace LR_1_Default.ViewModels
{
    public class OneWayBindingViewModel : INotifyPropertyChanged
    {
        private string _sourceText;
        private int _counter;
        private double _sliderValue;

        public string SourceText
        {
            get => _sourceText;
            set
            {
                _sourceText = value;
                OnPropertyChanged(nameof(SourceText));
                OnPropertyChanged(nameof(ProcessedText));
            }
        }

        public string ProcessedText
        {
            get
            {
                if (string.IsNullOrEmpty(_sourceText))
                    return "Обработано: (пусто) | Длина: 0";
                return $"Обработано: {_sourceText.ToUpper()} | Длина: {_sourceText.Length}";
            }
        }

        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                OnPropertyChanged(nameof(Counter));
                OnPropertyChanged(nameof(CounterDisplay));
            }
        }

        public string CounterDisplay => $"Количество кликов: {_counter}";

        public double SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                OnPropertyChanged(nameof(SliderValue));
                OnPropertyChanged(nameof(SliderDisplay));
            }
        }

        public string SliderDisplay => $"Текущее значение: {_sliderValue:F0}";

        public OneWayBindingViewModel()
        {
            _sourceText = "Введите текст здесь...";
            _counter = 0;
            _sliderValue = 50;
        }

        public void IncrementCounter()
        {
            Counter++;
        }

        public void ResetCounter()
        {
            Counter = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}