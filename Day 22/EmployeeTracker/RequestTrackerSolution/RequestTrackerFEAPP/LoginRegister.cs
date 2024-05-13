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
    }
}
