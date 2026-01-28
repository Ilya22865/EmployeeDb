using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading.Tasks;
using ProjectPractika.Models;

namespace ProjectPractika.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<IEnumerable<Employee>> GetEmployeeByDepartmentAsync(string Department);
    Task<int> AddEmployeeAsync(Employee employee);
    Task<int> UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(Employee employee);
}