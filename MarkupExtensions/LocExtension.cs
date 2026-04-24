using System;
using System.Windows.Data;
using System.Windows.Markup;
using LR_1_Default.Services;

namespace LR_1_Default.MarkupExtensions
{
    public class LocExtension : MarkupExtension
    {
        [ConstructorArgument("key")]
        public string Key { get; set; }

        public LocExtension() { }

        public LocExtension(string key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Key))
                return string.Empty;

            var service = LocalizationService.Instance;

            // Правильный синтаксис для индексатора с уведомлением об изменениях
            var binding = new Binding
            {
                Source = service,
                Path = new System.Windows.PropertyPath($"Item[{Key}]"),
                Mode = BindingMode.OneWay
            };

            return binding.ProvideValue(serviceProvider);
        }
    }
}