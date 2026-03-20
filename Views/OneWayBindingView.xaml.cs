using System.Windows;
using System.Windows.Controls;
using LR_1_Default.ViewModels;

namespace LR_1_Default.Views
{
    public partial class OneWayBindingView : UserControl
    {
        public OneWayBindingView()
        {
            InitializeComponent();
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is OneWayBindingViewModel vm)
            {
                vm.IncrementCounter();
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is OneWayBindingViewModel vm)
            {
                vm.ResetCounter();
            }
        }
    }
}