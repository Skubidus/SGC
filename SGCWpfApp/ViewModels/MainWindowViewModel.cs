using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SGCWpfApp.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
    private const string _appName = "Stationeers Gas Calculator (SGC) - by Skubidus";

    public string AppName => _appName;
}