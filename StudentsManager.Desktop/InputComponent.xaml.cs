using System.Windows.Controls;

namespace StudentsManager.Desktop;

public partial class InputComponent : UserControl
{
    public string LabelText { get; set; }
    
    public InputComponent()
    {
        InitializeComponent();
        
        Loaded += (sender, args) => Label_Input.Content = LabelText;
    }
}