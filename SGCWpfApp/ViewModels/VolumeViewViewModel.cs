using CommunityToolkit.Mvvm.ComponentModel;

using SGCLibrary;

namespace SGCWpfApp.ViewModels;
public partial class VolumeViewViewModel : ObservableObject
{
    private const string _viewTitle = "V = (n * R * T) / P";

    public string ViewTitle => _viewTitle;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Volume))]
    private double _moles;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Volume))]
    private double _temperature;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Volume))]
    private double _pressure;

    public double Volume
    {
        get
        {
            if (Moles <= 0 || Temperature <= 0 || Pressure <= 0
                || double.IsNaN(Moles) || double.IsNaN(Temperature) || double.IsNaN(Pressure))
            {
                return 0.0;
            }

            return double.Round(Calculations.CalculateVolume(Moles, Temperature, Pressure), 2);
        }
    }
}