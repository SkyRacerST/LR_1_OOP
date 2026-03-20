using System.ComponentModel;

namespace LR_1_Default.ViewModels
{
    public class TwoWayBindingViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _fullName;
        private bool _isChecked;
        private double _progressValue;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                UpdateFullName();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                UpdateFullName();
            }
        }

        public string FullName
        {
            get => _fullName;
            private set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
                OnPropertyChanged(nameof(StatusText));
            }
        }

        public string StatusText => IsChecked ? "Включено" : "Отключено";

        public double ProgressValue
        {
            get => _progressValue;
            set
            {
                _progressValue = value;
                OnPropertyChanged(nameof(ProgressValue));
                OnPropertyChanged(nameof(ProgressDisplay));
            }
        }

        public string ProgressDisplay => $"Прогресс: {_progressValue:F0}%";

        public TwoWayBindingViewModel()
        {
            _firstName = "Иван";
            _lastName = "Иванов";
            _isChecked = true;
            _progressValue = 50;
            UpdateFullName();
        }

        private void UpdateFullName()
        {
            FullName = $"{FirstName} {LastName}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}