using System.Linq;
using System.Windows;
using StudentsManager.Desktop.Model;

namespace StudentsManager.Desktop.Windows;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
    }

    private void Button_Auth_OnClick(object sender, RoutedEventArgs e)
    {
        var login = Input_Login.InputText;
        var password = Input_Password.InputPassword;
        
        var accounts = Account.Load(@"DB\accounts.json");
        var account = accounts?.SingleOrDefault(a => a.Login == login && a.Password == password);

        if (account == null)
        {
            MessageBox.Show(
                messageBoxText:"Неверный логин или пароль",
                caption:"Ошибка",
                MessageBoxButton.OK,
                icon:MessageBoxImage.Error);
            return;
        }
        
        var mainWindow = new MainWindow()
        {
            Account = account
        };
        mainWindow.Show();
        
        this.Close();
    }

    private void Button_Cancel_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}