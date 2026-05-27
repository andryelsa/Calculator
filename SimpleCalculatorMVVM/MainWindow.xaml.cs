using System.Windows;
using SimpleCalculatorMVVM.ViewModels;

namespace SimpleCalculatorMVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}