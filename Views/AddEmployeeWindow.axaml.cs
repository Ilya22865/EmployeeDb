using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ProjectPractika.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System;
using ProjectPractika.ViewModels;

namespace ProjectPractika;

public partial class AddEmployeeWindow : Window
{
    public AddEmployeeWindow()
    {
        InitializeComponent();
    }

    private void CloseWindow(object? sender, RoutedEventArgs e) {
        this.Close();
    }

    
}