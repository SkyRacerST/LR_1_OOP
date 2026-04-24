using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Collections.Generic;
using LR_1_Default.Resources;

namespace LR_1_Default.Services
{
    public class LocalizationService : INotifyPropertyChanged
    {
        private static LocalizationService _instance;
        public static LocalizationService Instance => _instance ??= new LocalizationService();

        private CultureInfo _currentCulture;
        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture?.Name != value?.Name)
                {
                    _currentCulture = value;
                    Thread.CurrentThread.CurrentCulture = value;
                    Thread.CurrentThread.CurrentUICulture = value;

                    // Вызываем событие смены культуры
                    OnCultureChanged?.Invoke();

                    // Обновляем все строки
                    LoadAllStrings();

                    OnPropertyChanged(nameof(CurrentCulture));
                }
            }
        }

        public event System.Action OnCultureChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public LocalizationService()
        {
            _currentCulture = new CultureInfo("ru-RU");
            LoadAllStrings();
        }

        // Метод для обновления всех строк и уведомления UI
        private void LoadAllStrings()
        {
            var resourceManager = Strings.ResourceManager;
            var resourceSet = resourceManager.GetResourceSet(_currentCulture, true, false);

            if (resourceSet != null)
            {
                foreach (System.Collections.DictionaryEntry entry in resourceSet)
                {
                    var key = entry.Key.ToString();
                    var value = entry.Value.ToString();

                    // Сохраняем строку
                    _cachedStrings[key] = value;

                    // Уведомляем об изменении конкретного ключа
                    OnPropertyChanged($"Item[{key}]");
                }
            }

            // Уведомляем об изменении всего индексатора
            OnPropertyChanged("Item[]");
        }

        private Dictionary<string, string> _cachedStrings = new Dictionary<string, string>();

        // Индексатор для доступа к строкам
        public string this[string key]
        {
            get
            {
                if (_cachedStrings.TryGetValue(key, out var value))
                    return value;

                // Если нет в кеше, пробуем загрузить напрямую
                var resourceManager = Strings.ResourceManager;
                var result = resourceManager.GetString(key, _currentCulture);
                if (result != null)
                {
                    _cachedStrings[key] = result;
                    return result;
                }

                return $"#{key}"; // Возвращаем ключ с маркером, если перевод не найден
            }
        }

        public void SetLanguage(string cultureName)
        {
            CurrentCulture = new CultureInfo(cultureName);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}