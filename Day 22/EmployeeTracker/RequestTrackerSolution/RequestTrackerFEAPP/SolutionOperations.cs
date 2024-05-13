using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RequestTrackerFEAPP
{
    public class SolutionOperations
    {
        RequestSolutionBL requestSolutionBL;
        RequestBL requestBL;
        InputOperations inputOperations;
        public SolutionOperations() { 
            requestSolutionBL = new RequestSolutionBL();
            inputOperations = new InputOperations();
            requestBL = new RequestBL();
        }

        public async Task ViewAllSolutions()
        {
            await Console.Out.WriteLineAsync("Enter Request ID:");
            int id = inputOperations.GetIntInput();
            Request requestSolution = await requestSolutionBL.ViewAllRequestSolutions(id);
            await Console.Out.WriteLineAsync("RequestID\tSolutionID\tDescription\tSolved Date\tSolved By\tIs Solved\t Comment");
            foreach (RequestSolution solution in requestSolution.RequestSolutions) {
                await Console.Out.WriteLineAsync(solution.RequestId+"\t"+solution.SolutionId+"\t"+solution.SolutionDescription+"\t"+solution.SolvedDate+"\t"+solution.SolvedBy+"\t"+solution.IsSolved+"\t"+solution.RequestRaiserComment);
            }
        }

        public async Task ViewAllSolutionsAdmin()
        {
            IList<RequestSolution> requestSolution = await requestSolutionBL.ViewAllRequestSolutionsAdmin();
            await Console.Out.WriteLineAsync("RequestID\tSolutionID\tDescription\tSolved Date\tSolved By\tIs Solved\t Comment");
            foreach (RequestSolution solution in requestSolution)
            {
                await Console.Out.WriteLineAsync(solution.RequestId + "\t" + solution.SolutionId + "\t" + solution.SolutionDescription + "\t" + solution.SolvedDate + "\t" + solution.SolvedBy + "\t" + solution.IsSolved + "\t" + solution.RequestRaiserComment);
            }
        }

        public async Task RespondToSolution()
        {
            await Console.Out.WriteLineAsync("Enter Solution ID:");
            int id = inputOperations.GetIntInput();
            await Console.Out.WriteLineAsync("Enter Comments:");
            string comments = inputOperations.GetStringInput();
            RequestSolution requestSolution = await requestSolutionBL.RespondToSolution(id, comments);
            if(requestSolution != null)
            {
                await Console.Out.WriteLineAsync("Solution Updated successfully!");
            }
            else
            {
                await Console.Out.WriteLineAsync("Error Updating solution!");
            }
        }

        public async Task ProvideSolution()
        {
            RequestSolution solution = new RequestSolution();
            int id;

            await Console.Out.WriteLineAsync("Enter Solution Description:");
            solution.SolutionDescription = inputOperations.GetStringInput();
            solution.SolvedDate = DateTime.Now;

            await Console.Out.WriteLineAsync("Enter Request ID:");
            id = inputOperations.GetIntInput();
            solution.RequestId = id;
            solution.IsSolved = false;
            RequestSolution requestSolution = await requestSolutionBL.GiveSolution(solution);

            if( requestSolution != null )
            {
                await Console.Out.WriteLineAsync("Solution Added successfully!");
            }
        }
    }
}
