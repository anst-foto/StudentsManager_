using System.Windows;

namespace StudentsManager.Desktop.Components;

public partial class InputTextComponent : InputComponent
{
    public static readonly DependencyProperty InputTextProperty = 
        DependencyProperty.Register(nameof(InputText), typeof(string), typeof(InputTextComponent));

    public string InputText
    {
        get => (string)GetValue(InputTextProperty); 
        set => SetValue(InputTextProperty, value);
    }
    
    public InputTextComponent()
    {
        InitializeComponent();
    }
}