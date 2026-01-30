using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectPractika.Models;
using ProjectPractika.Services;

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
            !decimal.TryParse(Salary, out var salary))
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
            DateOfEmployment = Dateofemployment
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

            _employeeService.UpdateEmployeeAsync(SelectedEmployee);

            var temp = Employees[index];
            Employees[index] = null;
            Employees[index] = temp;
            SelectedEmployee = null;    
        }
    }
}
