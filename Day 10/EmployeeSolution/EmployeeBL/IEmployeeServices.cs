using ModelClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public interface IEmployeeServices
    {
        int AddEmployee(Employee employee);
        List<Employee> GetEmployeesByEmployeeRole(string role);
        Employee GetEmployeeById(int employeeId);
        Department GetDepartmentByEmployeeId(int employeeId);
        List<Employee> GetAllEmployees();
        string GetEmployeeName(int employeeId);
        string GetEmployeeRole(int employeeId);
        Employee UpdateEmployeeName(string EmployeeOldName, string EmployeeNewName);
        Employee UpdateEmployeeSalaryById(int employeeId, double NewSalary);
        Employee DeleteEmployeeByID(int employeeId);
    }
}
