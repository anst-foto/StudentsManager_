using System.Windows;
using WpfApp4;

namespace StudentsManager.Desktop;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
    }

    private void Button_Auth_OnClick(object sender, RoutedEventArgs e)
    {
        /*var mainWindow = new MainWindow();
        mainWindow.Owner = this;
        mainWindow.ShowDialog();*/

        var mainWindow = new MainWindow()
        {
            Account = new Account()
            {
                Id = Guid.NewGuid(),
                LastName = "Starinin",
                FirstName = "Andrey",
                Login = "admin",
                Password = "12345"
            }
        };
        mainWindow.Show();
        
        this.Close();
    }

    private void Button_Cancel_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}