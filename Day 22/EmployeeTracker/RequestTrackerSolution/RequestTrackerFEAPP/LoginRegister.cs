using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class LoginRegister
    {
        InputOperations inputOperations;
        IEmployeeLoginBL EmployeeLoginBL;
        public LoginRegister() { 
            inputOperations = new InputOperations();
            EmployeeLoginBL = new EmployeeLoginBL();
        }
        async Task<Employee> EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            var result = await employeeLoginBL.Login(employee);
            if (result!=null)
            {
                await Console.Out.WriteLineAsync("Login Success");
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
            return result;
        }
        public async Task<Employee> GetLoginDeatils()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            return await EmployeeLoginAsync(id, password);
        }

        public async Task<Employee> RegisterEmployee()
        {
            await Console.Out.WriteLineAsync("Enter Employee Name:");
            string name = inputOperations.GetStringInput();
            await Console.Out.WriteLineAsync("Enter Employee Role:");
            string role = inputOperations.GetStringInput();
            await Console.Out.WriteLineAsync("Enter Password:");
            string password = inputOperations.GetStringInput();
            Employee employee = new Employee();
            employee.Name = name;
            employee.Password = password;
            employee.Role = role;
            Employee employeeAdded = await EmployeeLoginBL.Register(employee);
            if(employeeAdded!=null) {
                await Console.Out.WriteLineAsync("Employee Registered!"+employeeAdded.Id);
                return employeeAdded;
            }
            return null;
        }
    }
}
