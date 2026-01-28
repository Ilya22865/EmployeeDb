using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.Data.Sqlite;
using Avalonia.Media.TextFormatting;
using Tmds.DBus.Protocol;
using System.IO;
using System;
using ProjectPractika.ViewModels;

namespace ProjectPractika.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void DesignButton(object? sender, RoutedEventArgs e) {
        DepName.Text = "Дизайнерский отдел";
    }

    private void DevelopButton(object? sender, RoutedEventArgs e) {
        DepName.Text = "Отдел разработки";    
    }
    
    private void HRButton(object? sender, RoutedEventArgs e) {
        DepName.Text = "Отдел HR";    
    }

     private void AllButton(object? sender, RoutedEventArgs e) {
        DepName.Text = "Все сотрудники";    
    }
    private void NewEmployee(object? sender, RoutedEventArgs e)
    {
        var addWindow = new AddEmployeeWindow
        {
            DataContext = this.DataContext
        };
        
        addWindow.Show();
    }
    private void EditEmployee(object? sender, RoutedEventArgs e) {
        if(DataContext is MainWindowViewModel mainVm && mainVm.SelectedEmployee is not null) {
                var editWindow = new EditEmployeeWindow {
                DataContext = this.DataContext
            };
            editWindow.Show();
        } else {
            var ErrorEdit = new ErrorEdit {
                DataContext = this.DataContext
            };
            ErrorEdit.Show();
        }
    }
}
