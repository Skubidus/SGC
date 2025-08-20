using SGCWpfApp.ViewModels;

using System.ComponentModel;
using System.Windows;

namespace SGCWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel => (MainWindowViewModel)DataContext;

        public MainWindow()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}