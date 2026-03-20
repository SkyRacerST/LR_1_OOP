using CommunityToolkit.Mvvm.ComponentModel;

namespace LR_1_Toolkit.ViewModels
{
    public partial class TwoWayBindingViewModel : ObservableObject
    {
        private string _firstName = "Иван";
        private string _lastName = "Иванов";

        [ObservableProperty]
        private bool _isChecked = true;

        [ObservableProperty]
        private double _progressValue = 50;

        // Используем полные свойства с вызовом OnPropertyChanged для обновления FullName
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (SetProperty(ref _firstName, value))
                {
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (SetProperty(ref _lastName, value))
                {
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        // Вычисляемое свойство
        public string FullName => $"{FirstName} {LastName}";

        public string StatusText => IsChecked ? "Включено" : "Отключено";

        public string ProgressDisplay => $"Прогресс: {ProgressValue:F0}%";
    }
}