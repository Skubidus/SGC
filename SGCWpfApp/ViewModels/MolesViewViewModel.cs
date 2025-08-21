using CommunityToolkit.Mvvm.ComponentModel;

using SGCLibrary;

namespace SGCWpfApp.ViewModels;
public partial class MolesViewViewModel : ObservableObject
{
    private const string _viewTitle = "n = (P * V) / (R * T)";

    public string ViewTitle => _viewTitle;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Moles))]
    private double _pressure;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Moles))]
    private double _volume;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Moles))]
    private double _temperature;

    public double Moles
    {
        get
        {
            if (Pressure <= 0 || Volume <= 0 || Temperature <= 0
                || double.IsNaN(Pressure) || double.IsNaN(Volume) || double.IsNaN(Temperature))
            {
                return 0.0;
            }

            return double.Round(Calculations.CalculateMoles(Pressure, Volume, Temperature), 2);
        }
    }
}