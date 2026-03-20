using System.Windows;
using LR_1_Toolkit.ViewModels;

namespace LR_1_Toolkit
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