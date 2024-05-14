using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        private static async Task<Employee> Login(LoginRegister loginRegister, InputOperations inputOperations)
        {
            bool IsloggedIn = false;
            Employee employee = null;
            do
            {
                Console.Out.WriteLine("---------------------------------------------------");
                Console.Out.WriteLine("---------------------------------------------------");
                await Console.Out.WriteLineAsync("0. Exit");
                await Console.Out.WriteLineAsync("1. Login");
                await Console.Out.WriteLineAsync("2. Register");
                await Console.Out.WriteLineAsync("Choose Operation:");

                int input = inputOperations.GetIntInput();
                Console.Out.WriteLine("---------------------------------------------------");

                if (input == 0)
                {
                    IsloggedIn = true;
                }
                else if (input == 1)
                {
                    employee = await loginRegister.GetLoginDeatils();
                    if (employee != null)
                    {
                        IsloggedIn = true;
                    }
                    else
                    {
                        await Console.Out.WriteLineAsync("Invalid Credentials. Try Again");
                    }
                }
                else if (input == 2)
                {
                    employee = await loginRegister.RegisterEmployee();
                    if (employee != null)
                    {
                        IsloggedIn = true;
                    }
                }
            } while (!IsloggedIn);

            return employee;
        }

        static async Task Main(string[] args)
        {
            LoginRegister loginRegister = new LoginRegister();
            InputOperations inputOperations = new InputOperations();
            Operations operations = new Operations();

            Employee employee;
            
            do
            {
                bool IsloggedIn = true;
                employee = await Login(loginRegister, inputOperations);
                if (employee==null)
                    return;
                else
                {
                    if (employee.Role == "Admin")
                    {
                        Console.WriteLine("Logged in as Admin");
                        do
                        {
                            int run = await operations.AdminOperations(employee.Id);
                            if (run == 0)
                            {
                                IsloggedIn = false;
                            }

                        } while (IsloggedIn);

                    }
                    else
                    {
                        Console.WriteLine("Logged in as User");
                        do
                        {
                            int run = await operations.UserOperations(employee.Id);
                            if (run == 0)
                            {
                                IsloggedIn = false;
                            }

                        } while (IsloggedIn);

                    }
                }
            } while (employee!=null);
                
        }
    }
}
