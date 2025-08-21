using SGCWpfApp.ViewModels;
using SGCWpfApp.Views;

using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var control = sender as TabControl;
            if (control is null)
            {
                return;
            }

            var newTab = control.SelectedContent as UserControl;
            if (newTab is null)
            {
                return;
            }

            var removedItems = e.RemovedItems.Cast<TabItem>();
            UserControl? oldTab = null;

            if (removedItems.Any())
            {
                oldTab = removedItems.First().Content as UserControl;
                if (oldTab is null)
                {
                    return;
                }

                Debug.WriteLine($"Old Tab: {oldTab.Name}");
            }

            Debug.WriteLine($"New Tab: {newTab.Name}");
            Debug.WriteLine("");

            // sorry! i know this sucks but it works ¯\_(ツ)_/¯
            if (newTab.Name == nameof(MolesView))
            {
                TransferPropertiesToMolesTab(newTab, oldTab);
            }
            else if (newTab.Name == nameof(PressureView))
            {
                TransferPropertiesToPressureTab(newTab, oldTab);
            }
            else if (newTab.Name == nameof(VolumeView))
            {
                TransferPropertiesToVolumeTab(newTab, oldTab);
            }
            else if (newTab.Name == nameof(TemperatureView))
            {
                TransferPropertiesToTemperatureTab(newTab, oldTab);
            }
        }

        private static void TransferPropertiesToMolesTab(UserControl newTab, UserControl? oldTab)
        {
            if (oldTab is null)
            {
                return;
            }

            var newTabViewModel = ((MolesViewViewModel)newTab.DataContext);

            var oldTabViewModelType = oldTab.DataContext.GetType();
            object dataContext = oldTab.DataContext;

            var propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Pressure));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Pressure = (double)value;
                }
            }

            propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Volume));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Volume = (double)value;
                }
            }

            propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Temperature));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Temperature = (double)value;
                }
            }
        }

        private static void TransferPropertiesToPressureTab(UserControl newTab, UserControl? oldTab)
        {
            if (oldTab is null)
            {
                return;
            }

            var newTabViewModel = ((PressureViewViewModel)newTab.DataContext);

            var oldTabViewModelType = oldTab.DataContext.GetType();
            object dataContext = oldTab.DataContext;

            var propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Moles));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Moles = (double)value;
                }
            }

            propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Temperature));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Temperature = (double)value;
                }
            }

            propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Volume));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Volume = (double)value;
                }
            }
        }

        private static void TransferPropertiesToVolumeTab(UserControl newTab, UserControl? oldTab)
        {
            if (oldTab is null)
            {
                return;
            }

            var newTabViewModel = ((VolumeViewViewModel)newTab.DataContext);

            var oldTabViewModelType = oldTab.DataContext.GetType();
            object dataContext = oldTab.DataContext;

            var propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Moles));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Moles = (double)value;
                }
            }

            propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Temperature));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Temperature = (double)value;
                }
            }

            propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Pressure));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Pressure = (double)value;
                }
            }
        }

        private static void TransferPropertiesToTemperatureTab(UserControl newTab, UserControl? oldTab)
        {
            if (oldTab is null)
            {
                return;
            }

            var newTabViewModel = ((TemperatureViewViewModel)newTab.DataContext);

            var oldTabViewModelType = oldTab.DataContext.GetType();
            object dataContext = oldTab.DataContext;

            var propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Pressure));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Pressure = (double)value;
                }
            }

            propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Volume));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Volume = (double)value;
                }
            }

            propertyInfo = oldTabViewModelType.GetProperty(nameof(newTabViewModel.Moles));
            if (propertyInfo is not null)
            {
                var value = propertyInfo.GetValue(dataContext);
                if (value is not null)
                {
                    newTabViewModel.Moles = (double)value;
                }
            }
        }
    }
}