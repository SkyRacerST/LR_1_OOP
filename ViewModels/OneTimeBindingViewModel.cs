using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LR_1_Toolkit.ViewModels
{
    public partial class OneTimeBindingViewModel : ObservableObject
    {
        // Однократная привязка - значения устанавливаются в конструкторе и не меняются
        public string WelcomeMessage { get; }
        public string ApplicationTitle { get; }
        public DateTime LoadTime { get; }
        public string Version { get; }
        public string Description { get; }

        public OneTimeBindingViewModel()
        {
            WelcomeMessage = "Добро пожаловать в демонстрацию однократной привязки!";
            ApplicationTitle = "WPF MVVM Демонстрационное приложение (CommunityToolkit)";
            LoadTime = DateTime.Now;
            Version = "1.0.0";
            Description = "Этот текст устанавливается один раз при инициализации и никогда не изменяется.\n" +
                         "Однократные привязки полезны для статического контента, такого как метки,\n" +
                         "заголовки и данные конфигурации, которые не изменяются во время выполнения.\n\n" +
                         "В этой версии используется CommunityToolkit.MVVM для упрощения кода.";
        }
    }
}