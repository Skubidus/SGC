using CommunityToolkit.Mvvm.ComponentModel;

using SGCLibrary;

namespace SGCWpfApp.ViewModels;
public partial class TemperatureViewViewModel : ObservableObject
{
    private const string _viewTitle = "T = (P * V) / (R * n)";

    public string ViewTitle => _viewTitle;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Temperature))]
    private double _pressure;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Temperature))]
    private double _volume;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Temperature))]
    private double _moles;

    public double Temperature
    {
        get
        {
            if (Pressure <= 0 || Volume <= 0 || Moles <= 0
                || double.IsNaN(Pressure) || double.IsNaN(Volume) || double.IsNaN(Moles))
            {
                return 0.0;
            }

            return double.Round(Calculations.CalculateTemperature(Pressure, Volume, Moles), 2);
        }
    }
}