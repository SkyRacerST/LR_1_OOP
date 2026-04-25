using System.ComponentModel;
using LocalizationLibrary;

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
                var loc = LocalizationManager.Instance;
                if (string.IsNullOrEmpty(_sourceText))
                    return $"{loc["Processed"]}: ({loc["Empty"]}) | {loc["Length"]}: 0";
                return $"{loc["Processed"]}: {_sourceText.ToUpper()} | {loc["Length"]}: {_sourceText.Length}";
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

        public string CounterDisplay => $"{LocalizationManager.Instance["ClickCount"]}: {_counter}";

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

        public string SliderDisplay => $"{LocalizationManager.Instance["CurrentValue"]}: {_sliderValue:F0}";

        public OneWayBindingViewModel()
        {
            _sourceText = LocalizationManager.Instance["EnterTextHere"];
            _counter = 0;
            _sliderValue = 50;

            LocalizationManager.Instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Item[]")
                {
                    SourceText = LocalizationManager.Instance["EnterTextHere"];
                    OnPropertyChanged(nameof(ProcessedText));
                    OnPropertyChanged(nameof(CounterDisplay));
                    OnPropertyChanged(nameof(SliderDisplay));
                }
            };
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