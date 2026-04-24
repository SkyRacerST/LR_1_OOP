using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;

namespace LR_1_Default.Services
{
    public class XamlLocalizationService : INotifyPropertyChanged
    {
        private static XamlLocalizationService _instance;
        public static XamlLocalizationService Instance => _instance ??= new XamlLocalizationService();

        private ResourceDictionary _currentDictionary;
        private string _currentCulture;

        public string CurrentCulture
        {
            get => _currentCulture;
            private set
            {
                _currentCulture = value;
                OnPropertyChanged(nameof(CurrentCulture));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private XamlLocalizationService()
        {
            _currentCulture = "ru";
            LoadDictionary("ru");
        }

        public void SetLanguage(string culture)
        {
            if (_currentCulture != culture)
            {
                CurrentCulture = culture;
                LoadDictionary(culture);

                // Обновляем словарь в ресурсах приложения
                UpdateApplicationResources();
            }
        }

        private void LoadDictionary(string culture)
        {
            var uri = new Uri($"Resources/StringResources.{culture}.xaml", UriKind.Relative);
            _currentDictionary = new ResourceDictionary { Source = uri };
        }

        private void UpdateApplicationResources()
        {
            // Удаляем старый словарь и добавляем новый
            var appResources = Application.Current.Resources;
            var oldDict = appResources.MergedDictionaries[appResources.MergedDictionaries.Count - 1];
            appResources.MergedDictionaries.Remove(oldDict);
            appResources.MergedDictionaries.Add(_currentDictionary);

            OnPropertyChanged("Resources");
        }

        public object GetResource(string key)
        {
            if (_currentDictionary != null && _currentDictionary.Contains(key))
            {
                return _currentDictionary[key];
            }
            return key;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}