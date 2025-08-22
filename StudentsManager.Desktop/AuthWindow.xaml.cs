using System.Windows;

namespace StudentsManager.Desktop;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
    }

    private void Button_Auth_OnClick(object sender, RoutedEventArgs e)
    {
        var login = Input_Login.Text;
        var password = Input_Password.Password;
        
        var accounts = Account.Load();
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