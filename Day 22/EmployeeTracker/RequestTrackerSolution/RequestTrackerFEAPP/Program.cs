using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {

        void ShowUserListOperations()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request Status");
            Console.WriteLine("3. View Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to Solution");
        }

        void ShowAdminListOperations()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View All Request Status");
            Console.WriteLine("3. View All Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to Solution");
            Console.WriteLine("5. Provide Solution");
            Console.WriteLine("6. Mark Request as Closed");
            Console.WriteLine("7. View Feedbacks");
        }
        static async Task Main(string[] args)
        {
            Program program = new Program();
            LoginRegister loginRegister = new LoginRegister();
            InputOperations inputOperations = new InputOperations();


            Employee employee = await loginRegister.GetLoginDeatils();


            if(employee != null)
            {
                if(employee.Role == "Admin")
                {
                    int input;
                    do
                    {
                       program.ShowAdminListOperations();
                       input = inputOperations.GetIntInput();
                       switch (input)
                        {
                            case 0:
                                return;
                            case 1:


                        }

                    } while(true);
                   
                }
                else
                {
                    program.ShowUserListOperations();
                }
            }
            else
            {
               
            }
        }
    }
}
