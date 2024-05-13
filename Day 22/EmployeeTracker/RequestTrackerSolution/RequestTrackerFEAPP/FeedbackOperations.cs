using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class FeedbackOperations
    {
        SolutionFeedbackBL solutionFeedback;
        InputOperations inputOperations;
        EmployeeBL employeeBL;  
        RequestSolutionBL requestSolutionBL;

        public FeedbackOperations() { 
            solutionFeedback = new SolutionFeedbackBL();
            inputOperations = new InputOperations();
            employeeBL = new EmployeeBL();
            requestSolutionBL = new RequestSolutionBL();
        }

        public async Task GiveFeedBack(int Id)
        {
            SolutionFeedback feedback = new SolutionFeedback();
            int solutionID;

            feedback.Rating = inputOperations.GetFloatInput();
            feedback.Remarks = inputOperations.GetStringInput();
            feedback.FeedbackDate = DateTime.Now;
            feedback.FeedbackBy = Id;

            await Console.Out.WriteLineAsync("Enter Solution ID:");
            solutionID = inputOperations.GetIntInput();
            feedback.SolutionId = solutionID;
            SolutionFeedback solutionFeedbackresult = await solutionFeedback.GiveFeedbackOnSolution(feedback);
            if(solutionFeedbackresult != null)
            {
                await Console.Out.WriteLineAsync("Feedback Added!");
            }
            else
            {
                await Console.Out.WriteLineAsync("Error Adding Feedback");
            }
        }
    }
}
