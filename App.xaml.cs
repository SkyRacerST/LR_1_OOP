using System.Windows;
using System.Globalization;
using System.Threading;
using LR_1_Default.Services;

namespace LR_1_Default
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Принудительно устанавливаем русскую культуру
            var culture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // Инициализируем сервис локализации
            LocalizationService.Instance.SetLanguage("ru-RU");
        }
    }
}