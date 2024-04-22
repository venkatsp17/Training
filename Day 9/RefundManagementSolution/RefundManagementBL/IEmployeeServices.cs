using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBL
{
    public interface IEmployeeServices
    {
        int AddEmployee(Employee employee);
        Employee GetEmployeeById(int employeeId);
        List<Employee> GetAllEmployees();
        string GetEmployeeName(int employeeId);
        string GetEmployeeDepartment(int employeeId);
        Employee UpdateEmployeeName(string EmployeeNewName, int employeeId);
        Employee UpdateEmployeeSalaryById(int employeeId, double NewSalary);
        Employee DeleteEmployeeByID(int employeeId);

        bool CanAuthorizeExpense(int employeeId);
    }
}
