using EmployeeBL;
using EmployeeBLLibrary.EmployeeExceptions;
using EmployeeBLLibrary.Exceptions;
using ModeClassDALLibrary;
using ModelClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeBLLibrary
{
    public class EmployeeBL : IEmployeeServices
    {
        readonly IRepository<int, Employee> _employeeRepository;
        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }

        //Function to Add Employee
        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateEmployeeException();
        }

        //Function to Delete Employee By ID
        public Employee DeleteEmployeeByID(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
               _employeeRepository.Delete(employee.Id);
            }
            throw new EmployeeNotFoundException();
        }

        //Function to Get All Employees
        public List<Employee> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            if (employees != null)
            {
                return new List<Employee>(employees);
            }
            throw new NoDataAvailableException();
        }

        //Function to Get Department By Employee ID
        public Department GetDepartmentByEmployeeId(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                return employee.EmployeeDepartment;
            }
            throw new EmployeeNotFoundException();
        }

        //Function to Get Employee By ID
        public Employee GetEmployeeById(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                return employee;
            }
            throw new EmployeeNotFoundException();
        }

        //Function to Get Employee Name
        public string GetEmployeeName(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                return employee.Name;
            }
            throw new EmployeeNotFoundException();
        }

        //Function to Get Employee Role
        public string GetEmployeeRole(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                return employee.Role;
            }
            throw new EmployeeNotFoundException();
        }

        //Function to Get All Employees Of Particular Role
        public List<Employee> GetEmployeesByEmployeeRole(string role)
        {
            var employees = _employeeRepository.GetAll();
            List<Employee> result = new List<Employee>();
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    if(employee.Role == role)
                    {
                        result.Add(employee);
                    }
                }
                return result;
            }
            throw new EmployeeNotFoundException();
        }

        //Function to Update Employee Name
        public Employee UpdateEmployeeName(string EmployeeOldName, string EmployeeNewName)
        {
            var employees = _employeeRepository.GetAll();
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    if (employee.Name == EmployeeOldName)
                    {
                       employee.Name = EmployeeNewName;
                        _employeeRepository.Update(employee);
                        return employee;
                    }
                }
              
            }
            throw new EmployeeNotFoundException();
        }

        //Function to Update Employee Salary By ID
        public Employee UpdateEmployeeSalaryById(int employeeId, double NewSalary)
        {
            var employees = _employeeRepository.GetAll();
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    if (employee.Id == employeeId)
                    {
                        employee.Salary = NewSalary;
                        _employeeRepository.Update(employee);
                        return employee;
                    }
                }

            }
            throw new EmployeeNotFoundException();
        }
    }
}
