using CommunityToolkit.Mvvm.ComponentModel;

using SGCLibrary;

namespace SGCWpfApp.ViewModels;
public partial class PressureViewViewModel : ObservableObject
{
    private const string _viewTitle = "P = (n * R * T) / V";

    public string ViewTitle => _viewTitle;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Pressure))]
    private double _moles;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Pressure))]
    private double _temperature;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Pressure))]
    private double _volume;

    public double Pressure
    {
        get
        {
            if (Moles <= 0 || Temperature <= 0 || Volume <= 0
                || double.IsNaN(Moles) || double.IsNaN(Temperature) || double.IsNaN(Volume))
            {
                return 0.0;
            }

            return double.Round(Calculations.CalculatePressure(Moles, Temperature, Volume), 2);
        }
    }
}