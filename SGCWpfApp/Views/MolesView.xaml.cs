using SGCWpfApp.ViewModels;

using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGCWpfApp.Views;
/// <summary>
/// Interaction logic for MolesView.xaml
/// </summary>
public partial class MolesView : UserControl
{
    public MolesViewViewModel ViewModel => (MolesViewViewModel)DataContext;

    public MolesView()
    {
        if (DesignerProperties.GetIsInDesignMode(this))
        {
            return;
        }

        InitializeComponent();
        DataContext = new MolesViewViewModel();
    }

    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var regex = new Regex(@"^[0-9]*\.?[0-9]*$");
        var textBox = sender as TextBox;
        var proposedText = textBox!.Text + e.Text;

        if (regex.IsMatch(proposedText) == false)
        {
            e.Handled = true;
            return;
        }

        if (e.Text == "." && textBox.Text.Contains('.'))
        {
            e.Handled = true;
            return;
        }
    }

    private void TextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
    {
        var textBox = sender as TextBox;
        textBox!.SelectAll();
    }
}
