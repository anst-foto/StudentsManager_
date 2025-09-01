using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StudentsManager.Desktop.Model;

namespace StudentsManager.Desktop.Windows;

public partial class MainWindow : Window
{
    private List<Student> _students;
    public required Account Account { get; init; }
    
    public MainWindow()
    {
        InitializeComponent();
        
        Loaded += OnLoaded;

        Closing += OnClosing;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        ListOfStudentsLoaded();
        
        MessageBox.Show(
            owner: this,
            caption: "Приветствие",
            messageBoxText: $"Добро пожаловать, {Account.FullName} {Account.Id:P}!", 
            icon: MessageBoxImage.Information,
            button: MessageBoxButton.OK
            );
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

    private void ListOfStudentsLoaded()
    {
        _students = Student
            .Load(@"DB/students.json")
            .ToList();
        ListOfStudents.ItemsSource = _students;
    }

    private void ListOfStudents_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListOfStudents.SelectedItem is not Student student) return;
        
        InputId.InputText = student.Id.ToString();
        InputLastName.InputText = student.LastName;
        InputFirstName.InputText = student.FirstName;
    }

    private void Clear()
    {
        InputId.InputText = string.Empty;
        InputLastName.InputText = string.Empty;
        InputFirstName.InputText = string.Empty;
        
        ListOfStudents.SelectedItem = null;
    }

    private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
    {
        Clear();
    }

    private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
    {
        var flag = InputId.InputText != string.Empty;
        if (flag)
        {
            var id = Guid.Parse(InputId.InputText);
            var student = _students.SingleOrDefault(s => s.Id == id);
            student.LastName = InputLastName.InputText;
            student.FirstName = InputFirstName.InputText;
        }
        else
        {
            _students.Add(new Student()
            {
                Id = Guid.NewGuid(),
                LastName = InputLastName.InputText,
                FirstName = InputFirstName.InputText,
                Faculty = ""
            });
        }
        
        Student.Save(_students, @"DB\students.json");
            
        Clear();

        ListOfStudentsLoaded();
    }
}