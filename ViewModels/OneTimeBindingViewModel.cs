using System;

namespace LR_1_Default.ViewModels
{
    public class OneTimeBindingViewModel
    {
        public string WelcomeMessage { get; }
        public string ApplicationTitle { get; }
        public DateTime LoadTime { get; }
        public string Version { get; }
        public string Description { get; }

        public OneTimeBindingViewModel()
        {
            WelcomeMessage = "Добро пожаловать в демонстрацию однократной привязки!";
            ApplicationTitle = "WPF MVVM Демонстрационное приложение";
            LoadTime = DateTime.Now;
            Version = "1.0.0";
            Description = "Этот текст устанавливается один раз при инициализации и никогда не изменяется.\n" +
                         "Однократные привязки полезны для статического контента, такого как метки,\n" +
                         "заголовки и данные конфигурации, которые не изменяются во время выполнения.";
        }
    }
}