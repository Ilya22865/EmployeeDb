using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProjectPractika.Data;
using ProjectPractika.Models;

namespace ProjectPractika.Services;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _context;

    public EmployeeService(ApplicationDbContext context) {
        _context = context;
    }
    public async Task<int> AddEmployeeAsync(Employee employee)
    {
        var context = _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return context.Entity.Id;
    }
    public async Task DeleteEmployeeAsync(Employee employee)
    {
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }
    public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentAsync(string Department)
    {
        var employees = new List<Employee>();

        const string connectionString = "Data Source=Employee.db";

        await using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();
        
        const string query = "Select * from Employees where Department = @department";

        await using var command = new SqliteCommand(query, connection);
        command.Parameters.AddWithValue("@department", Department);

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync()) {
            var employee = new Employee {
                Id = reader.GetInt32("Id"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                Department = reader.GetString("Department"),
                Salary = reader.GetDecimal("Salary"),
                DateOfBirth = reader.GetDateTime("DateOfBirth"),
                DateOfEmployment = reader.GetDateTime("DateOfEmployment")
            };
            employees.Add(employee);
        }
        return employees;
    }

    public async Task<int> UpdateEmployeeAsync(Employee employee)
    {
        var context = _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return context.Entity.Id;
    }
}