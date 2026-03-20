using System.Windows;
using LR_1_Default.ViewModels;

namespace LR_1_Default
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}