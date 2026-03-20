using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace LR_1_Toolkit.ViewModels
{
    public partial class TriggersViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isEnabled = true;

        [ObservableProperty]
        private bool _isVisible = true;

        [ObservableProperty]
        private int _selectedIndex = -1;

        [ObservableProperty]
        private ObservableCollection<string> _items;

        private string _inputText = "";

        // Используем полное свойство для InputText с вызовом OnPropertyChanged
        public string InputText
        {
            get => _inputText;
            set
            {
                if (SetProperty(ref _inputText, value))
                {
                    OnPropertyChanged(nameof(ValidationMessage));
                }
            }
        }

        public string ButtonText => IsEnabled ? "Кнопка включена" : "Кнопка отключена";

        public string ValidationMessage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(InputText))
                    return "⚠️ Поле не может быть пустым";
                if (InputText.Length < 3)
                    return "⚠️ Минимум 3 символа";
                if (InputText.Length > 20)
                    return "⚠️ Максимум 20 символов";
                return "✓ Корректный ввод";
            }
        }

        public string SelectionMessage
        {
            get
            {
                if (SelectedIndex < 0 || SelectedIndex >= Items.Count)
                    return "Элемент не выбран";
                return $"Выбрано: {Items[SelectedIndex]}";
            }
        }

        public TriggersViewModel()
        {
            Items = new ObservableCollection<string>
            {
                "Вариант 1",
                "Вариант 2",
                "Вариант 3",
                "Вариант 4"
            };
        }

        // Частичные методы для обновления связанных свойств
        partial void OnIsEnabledChanged(bool value)
        {
            OnPropertyChanged(nameof(ButtonText));
        }

        partial void OnSelectedIndexChanged(int value)
        {
            OnPropertyChanged(nameof(SelectionMessage));
        }
    }
}