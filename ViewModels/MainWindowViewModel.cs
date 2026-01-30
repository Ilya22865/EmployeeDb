using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectPractika.Models;
using ProjectPractika.Services;
using System.Net;
using System.Net.Mail;

namespace ProjectPractika.ViewModels;


public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IEmployeeService _employeeService;
    [ObservableProperty] private ObservableCollection<Employee> _employees;
    [ObservableProperty] private Employee? _selectedEmployee;
    [ObservableProperty] private string? _saveBtn = "Добавить";
    [ObservableProperty] private string? _HRButton = "HR";
    [ObservableProperty] private string? _DevButton = "Develop";
    [ObservableProperty] private string? _DesignButton = "Design";
    [ObservableProperty] private string? _firstname;
    [ObservableProperty] private string? _lastname;
    [ObservableProperty] private string? _department;
    [ObservableProperty] private string? _salary;
    [ObservableProperty] private DateTimeOffset _dateofbirth = DateTimeOffset.Now.Date;
    [ObservableProperty] private DateTimeOffset _dateofemployment = DateTimeOffset.Now.Date;
    [ObservableProperty] private string? _email;
    [ObservableProperty] private string? _theme;
    [ObservableProperty] private string? _maintext;


    public MainWindowViewModel(IEmployeeService employeeService) {
        _employeeService = employeeService;
        _employees = new ObservableCollection<Employee>();
        AllEmployees();
    }
    
    [RelayCommand]
    private async void AllEmployees() {
        Employees.Clear();
        var allEmployee = await _employeeService.GetAllEmployeesAsync();
        foreach (var employee in allEmployee) {
            Employees.Add(employee); 
        }
    }

    [RelayCommand]
    private async void Hr() {
        Employees.Clear();
        var depEmployee = await _employeeService.GetEmployeeByDepartmentAsync("HR");
        foreach (var employee in depEmployee) {
            Employees.Add(employee);
        }
    } 

    [RelayCommand]
    private async void Develop() {
        Employees.Clear();
        var depEmployee = await _employeeService.GetEmployeeByDepartmentAsync("Develop");
        foreach (var employee in depEmployee) {
            Employees.Add(employee);
        }
    }

    [RelayCommand]
    private async void Design() {
        Employees.Clear();
        var depEmployee = await _employeeService.GetEmployeeByDepartmentAsync("Design");
        foreach (var employee in depEmployee) {
            Employees.Add(employee);
        }
    }
    
    private bool TryParseEmployee(out Employee employee)
    {   
        
        employee = null!;

        if (string.IsNullOrWhiteSpace(Firstname) ||
            string.IsNullOrWhiteSpace(Lastname) ||
            string.IsNullOrWhiteSpace(Department) ||
            !(Department == "HR" || Department == "Develop" || Department == "Design") ||
            !decimal.TryParse(Salary, out var salary) ||
            string.IsNullOrWhiteSpace(Email))
        {
            return false;
            
        }

        employee = new Employee
        {
            FirstName = Firstname!,
            LastName = Lastname!,
            Department = Department!,
            Salary = salary,
            DateOfBirth = Dateofbirth,
            DateOfEmployment = Dateofemployment,
            Email = Email
        };

        return true;
    }

    [RelayCommand]
    private async Task SaveEmployee() {
        if(!TryParseEmployee(out var employee)) {
            return;
        }
        
        var eId = await _employeeService.AddEmployeeAsync(employee);
        employee.Id = eId;
        Employees.Add(employee);
       
    }

    [RelayCommand]
    private void Clear() {
        Firstname = string.Empty;
        Lastname = string.Empty;
        Department = string.Empty;
        Salary = string.Empty;        
    }

    [RelayCommand]
    private async Task DeleteEmployee() {
        if(SelectedEmployee is not null) {
            _employeeService.DeleteEmployeeAsync(SelectedEmployee);
            Employees.Remove(SelectedEmployee);
            SelectedEmployee = null;
        }
    }

    partial void OnSelectedEmployeeChanged(Employee? value)
    {
        if(value is not null) {
            Firstname = value.FirstName;
            Lastname = value.LastName;
            Department = value.Department;
            Salary = Convert.ToString(value.Salary);
            Dateofbirth = value.DateOfBirth;
            Dateofemployment = value.DateOfEmployment;
            Email = value.Email;
        } else {
            Clear();
        }
        
    }

    [RelayCommand]
    private async Task EditEmployee() {
        if (SelectedEmployee is not null) {
            var index = Employees.IndexOf(SelectedEmployee);
            SelectedEmployee.FirstName = Firstname;
            SelectedEmployee.LastName = Lastname;
            SelectedEmployee.Department = Department;
            SelectedEmployee.Salary = Convert.ToDecimal(Salary);
            SelectedEmployee.DateOfBirth = Dateofbirth;
            SelectedEmployee.DateOfEmployment = Dateofemployment;
            SelectedEmployee.Email = Email;
            _employeeService.UpdateEmployeeAsync(SelectedEmployee);

            var temp = Employees[index];
            Employees[index] = null;
            Employees[index] = temp;
            SelectedEmployee = null;    
        }
    }

    [RelayCommand]
    private async Task EmailEmployee() {
        if (SelectedEmployee is not null) {
            var index = Employees.IndexOf(SelectedEmployee);
            
            SelectedEmployee.Email = Email;

            var temp = Employees[index];
            Employees[index] = null;
            Employees[index] = temp;
            SelectedEmployee = null;    
        }
    }


    [RelayCommand]
    private async Task SendEmail() {
        try {
            string? SenderEmail = "hribanov555@gmail.com";
            string? SenderEmailPassword = "avja fsof dcmj agnf";

            string? recieverEmail = SelectedEmployee.Email;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(SenderEmail, SenderEmailPassword);
            smtpClient.EnableSsl = true;
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(SenderEmail);
            mailMessage.Subject = Theme;
            mailMessage.Body = Maintext;
            mailMessage.IsBodyHtml = true;

            mailMessage.To.Add(recieverEmail);
            smtpClient.Send(mailMessage);
            Console.WriteLine("Mail Send");
        } catch {
            Console.WriteLine("Error");
        }
    }
}
