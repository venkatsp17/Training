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
            Console.WriteLine("6. Provide Solution");
            Console.WriteLine("7. Mark Request as Closed");
            //Console.WriteLine("8. View Feedbacks");
        }
        static async Task Main(string[] args)
        {
            Program program = new Program();
            LoginRegister loginRegister = new LoginRegister();
            InputOperations inputOperations = new InputOperations();
            RequestOperations requestOperations = new RequestOperations();
            SolutionOperations solutionOperations = new SolutionOperations();
            FeedbackOperations feedbackOperations = new FeedbackOperations();


            Employee employee = await loginRegister.GetLoginDeatils();


            if(employee != null)
            {
                int input;
                if (employee.Role == "Admin")
                {
       
                    do
                    {
                       program.ShowAdminListOperations();
                       input = inputOperations.GetIntInput();
                       switch (input)
                        {
                            case 0:
                                return;
                            case 1:
                               await requestOperations.RaiseNewRequest(employee.Id);
                               break;
                            case 2:
                               await requestOperations.ViewAllRequestStatusAdmin();
                               break;
                            case 3:
                                await solutionOperations.ViewAllSolutionsAdmin();
                                break;
                            case 4:
                                await feedbackOperations.GiveFeedBack(employee.Id);
                                break;
                            case 5:
                                await solutionOperations.RespondToSolution();
                                break;
                            case 6:
                                await solutionOperations.ProvideSolution();
                                break;
                            case 7:
                                await requestOperations.UpdateClosed(employee.Id);
                                break;
                            default:
                                await Console.Out.WriteLineAsync("Invalid Operation!");
                                break;
                        }

                    } while(true);
                   
                }
                else
                {
                    do
                    {
                        program.ShowUserListOperations();
                        input = inputOperations.GetIntInput();
                        switch (input)
                        {
                            case 0:
                                return;
                            case 1:
                                await requestOperations.RaiseNewRequest(employee.Id);
                                break;
                            case 2:
                                await requestOperations.ViewAllRequestStatus(employee.Id);
                                break;
                            case 3:
                                await solutionOperations.ViewAllSolutions();
                                break;
                            case 4:
                                await feedbackOperations.GiveFeedBack(employee.Id);
                                break;
                            case 5:
                                await solutionOperations.RespondToSolution();
                                break;
                            default:
                                await Console.Out.WriteLineAsync("Invalid Operation!");
                                break;

                        }

                    } while (true);

                }
            }
            else
            {
                await Console.Out.WriteLineAsync("Invalid Login Credentials");
            }
        }
    }
}
