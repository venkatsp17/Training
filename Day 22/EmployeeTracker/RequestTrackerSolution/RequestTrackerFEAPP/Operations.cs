using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class Operations
    {
        LoginRegister loginRegister;
        InputOperations inputOperations;
        RequestOperations requestOperations;
        SolutionOperations solutionOperations;
        FeedbackOperations feedbackOperations;
        public Operations() {
            loginRegister = new LoginRegister();
            inputOperations = new InputOperations();
            requestOperations = new RequestOperations();
            solutionOperations = new SolutionOperations();
            feedbackOperations = new FeedbackOperations();
        }
        void ShowAdminListOperations()
        {
            Console.Out.WriteLine("---------------------------------------------------");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View All Request Status");
            Console.WriteLine("3. View All Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to Solution");
            Console.WriteLine("6. Provide Solution");
            Console.WriteLine("7. Mark Request as Closed");
            Console.Out.WriteLine("---------------------------------------------------");
            //Console.WriteLine("8. View Feedbacks");
        }
        public async Task<int> AdminOperations(int EmployeeID)
        {
            int input;
            ShowAdminListOperations();
            input = inputOperations.GetIntInput();
            switch (input)
            {
                case 0:
                    return 0;
                case 1:
                    await requestOperations.RaiseNewRequest(EmployeeID);
                    return 1;
                case 2:
                    await requestOperations.ViewAllRequestStatusAdmin();
                    return 1;

                case 3:
                    await solutionOperations.ViewAllSolutionsAdmin();
                    return 1;
                case 4:
                    await feedbackOperations.GiveFeedBack(EmployeeID);
                    return 1;

                case 5:
                    await solutionOperations.RespondToSolution(EmployeeID);
                    return 1;
                case 6:
                    await solutionOperations.ProvideSolution(EmployeeID);
                    return 1;
                case 7:
                    await requestOperations.UpdateClosed(EmployeeID);
                    return 1;
                default:
                    await Console.Out.WriteLineAsync("Invalid Operation!");
                    return 1;
            }


        }

        void ShowUserListOperations()
        {
            Console.Out.WriteLine("---------------------------------------------------");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request Status");
            Console.WriteLine("3. View Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to Solution");
            Console.Out.WriteLine("---------------------------------------------------");
        }

        public async Task<int> UserOperations(int EmployeeID)
        {
            ShowUserListOperations();
            int input = inputOperations.GetIntInput();
            switch (input)
            {
                case 0:
                    return 0;
                case 1:
                    await requestOperations.RaiseNewRequest(EmployeeID);
                    return 1;
                case 2:
                    await requestOperations.ViewAllRequestStatus(EmployeeID);
                    return 1;
                case 3:
                    await solutionOperations.ViewAllSolutions();
                    return 1;
                case 4:
                    await feedbackOperations.GiveFeedBack(EmployeeID);
                    return 1;
                case 5:
                    await solutionOperations.RespondToSolution(EmployeeID);
                    return 1;
                default:
                    await Console.Out.WriteLineAsync("Invalid Operation!");
                    return 1;

            }
        }
    }
}
