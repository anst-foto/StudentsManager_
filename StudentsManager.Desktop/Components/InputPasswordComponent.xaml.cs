using System.Windows;

namespace StudentsManager.Desktop.Components;

public partial class InputPasswordComponent : InputComponent
{
   public static readonly DependencyProperty InputPasswordProperty = 
        DependencyProperty.Register(nameof(InputPassword), typeof(string), typeof(InputTextComponent));

    public string InputPassword
    {
        get => (string)GetValue(InputPasswordProperty); 
        set => SetValue(InputPasswordProperty, value);
    }
    public InputPasswordComponent()
    {
        InitializeComponent();
    }
}