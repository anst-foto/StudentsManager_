using System.ComponentModel;
using System.Windows;
using WpfApp4;

namespace StudentsManager.Desktop;

public partial class MainWindow : Window
{
    public required Account Account { get; init; }
    
    public MainWindow()
    {
        InitializeComponent();
        
        Loaded += OnLoaded;

        Closing += OnClosing;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        MessageBox.Show(
            owner:this, 
            messageBoxText: $"Добро пожаловать, {Account.FullName} {Account.Id:P}!", 
            caption:"Приветствие", 
            MessageBoxButton.OK,
            icon:MessageBoxImage.Information);
    }

    private void OnClosing(object? sender, CancelEventArgs e)
    {
        var result = MessageBox.Show(
            owner: this,
            messageBoxText:"Вы действительно хотите закрыть приложение?",
            caption:"Вопрос",
            MessageBoxButton.YesNo,
            icon:MessageBoxImage.Question);
        if (result == MessageBoxResult.No)
        {
            e.Cancel = true;
        }
    }
}