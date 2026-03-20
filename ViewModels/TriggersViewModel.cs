using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace LR_1_Default.ViewModels
{
    public class TriggersViewModel : INotifyPropertyChanged
    {
        private bool _isEnabled;
        private bool _isVisible;
        private string _inputText;
        private int _selectedIndex;
        private ObservableCollection<string> _items;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        public string ButtonText => IsEnabled ? "Кнопка включена" : "Кнопка отключена";

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
                OnPropertyChanged(nameof(ValidationMessage));
            }
        }

        public string ValidationMessage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_inputText))
                    return "⚠️ Поле не может быть пустым";
                if (_inputText.Length < 3)
                    return "⚠️ Минимум 3 символа";
                if (_inputText.Length > 20)
                    return "⚠️ Максимум 20 символов";
                return "✓ Корректный ввод";
            }
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
                OnPropertyChanged(nameof(SelectionMessage));
            }
        }

        public string SelectionMessage
        {
            get
            {
                if (_selectedIndex < 0 || _selectedIndex >= _items.Count)
                    return "Элемент не выбран";
                return $"Выбрано: {_items[_selectedIndex]}";
            }
        }

        public ObservableCollection<string> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public TriggersViewModel()
        {
            _isEnabled = true;
            _isVisible = true;
            _inputText = "";
            _selectedIndex = -1;
            _items = new ObservableCollection<string>
            {
                "Вариант 1",
                "Вариант 2",
                "Вариант 3",
                "Вариант 4"
            };
        }

        public void ToggleEnabled()
        {
            IsEnabled = !IsEnabled;
        }

        public void ToggleVisibility()
        {
            IsVisible = !IsVisible;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}