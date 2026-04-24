using System;
using System.Windows.Data;
using System.Windows.Markup;
using LocalizationLibrary;

namespace LR_1_Default.MarkupExtensions
{
    public class LibraryLocExtension : MarkupExtension
    {
        [ConstructorArgument("key")]
        public string Key { get; set; }

        public LibraryLocExtension() { }

        public LibraryLocExtension(string key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Key))
                return string.Empty;

            var service = LocalizationManager.Instance;

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