using SGCWpfApp.ViewModels;

using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGCWpfApp.Views;
/// <summary>
/// Interaction logic for PressureView.xaml
/// </summary>
public partial class PressureView : UserControl
{
    public PressureViewViewModel ViewModel => (PressureViewViewModel)DataContext;

    public PressureView()
    {
        if (DesignerProperties.GetIsInDesignMode(this))
        {
            return;
        }

        InitializeComponent();
        DataContext = new PressureViewViewModel();
    }

    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox == null)
        {
            return;
        }

        if (char.IsDigit(e.Text[0]) == false && e.Text != ".")
        {
            e.Handled = true;
            return;
        }

        if (e.Text == "." && textBox.Text.Contains('.'))
        {
            e.Handled = true;
            return;
        }

        string newText = textBox.Text;
        int caretPosition = textBox.CaretIndex;

        if (textBox.SelectionLength > 0)
        {
            newText = newText.Remove(textBox.SelectionStart, textBox.SelectionLength);
        }

        if (e.Text == ".")
        {
            if (string.IsNullOrEmpty(newText) == false)
            {
                caretPosition = newText.Length;
            }
            else if (textBox.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }
        }

        newText = newText.Insert(caretPosition, e.Text);

        if (string.IsNullOrEmpty(newText) == false)
        {
            if (!Regex.IsMatch(newText, @"^(\d*\.?\d*)$"))
            {
                e.Handled = true;
                return;
            }
        }
    }

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        var textBox = sender as TextBox;
        textBox!.SelectAll();
    }

    private void TextBox_DataObjectPasting(object sender, DataObjectPastingEventArgs e)
    {
        var clipboardText = e.DataObject.GetData(typeof(string)) as string;
        if (clipboardText is null)
        {
            return;
        }

        if (Regex.IsMatch(clipboardText, @"^(\d*\.?\d*)$") == false)
        {
            e.CancelCommand();
        }
    }
}
