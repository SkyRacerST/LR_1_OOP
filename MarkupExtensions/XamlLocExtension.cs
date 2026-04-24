using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using LR_1_Default.Services;

namespace LR_1_Default.MarkupExtensions
{
    public class XamlLocExtension : MarkupExtension
    {
        [ConstructorArgument("key")]
        public string Key { get; set; }

        public XamlLocExtension() { }

        public XamlLocExtension(string key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Key))
                return string.Empty;

            var service = XamlLocalizationService.Instance;

            // Используем DynamicResource для автоматического обновления при смене словаря
            var resourceKey = Key;

            // Создаём DynamicResourceExtension
            return new DynamicResourceExtension(resourceKey).ProvideValue(serviceProvider);
        }
    }
}