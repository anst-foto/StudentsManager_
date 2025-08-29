using System.Windows;
using System.Windows.Controls;

namespace StudentsManager.Desktop.Components;

public abstract class InputComponent : UserControl
{
    public static readonly DependencyProperty LabelContentProperty = 
        DependencyProperty.Register(nameof(LabelContent), typeof(object), typeof(InputTextComponent));

    public object LabelContent
    {
        get => GetValue(LabelContentProperty); 
        set => SetValue(LabelContentProperty, value);
    }
}