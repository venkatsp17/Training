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

            try
            {
                Request requestSolution = await requestSolutionBL.ViewAllRequestSolutions(id);
                foreach (RequestSolution solution in requestSolution.RequestSolutions)
                {
                    await Console.Out.WriteLineAsync("---------------------------------------------------");
                    await Console.Out.WriteLineAsync("Request Number: " + solution.RequestId);
                    await Console.Out.WriteLineAsync("Solution ID: " + solution.SolutionId);
                    await Console.Out.WriteLineAsync("Description: " + solution.SolutionDescription);
                    await Console.Out.WriteLineAsync("Solved Date: " + solution.SolvedDate);
                    await Console.Out.WriteLineAsync("Solved By: " + solution.SolvedBy);
                    await Console.Out.WriteLineAsync("Comments: " + solution.RequestRaiserComment);
                    await Console.Out.WriteLineAsync("---------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
           
        }

        public async Task ViewAllSolutionsAdmin()
        {
            try
            {
                IList<RequestSolution> requestSolution = await requestSolutionBL.ViewAllRequestSolutionsAdmin();
                foreach (RequestSolution solution in requestSolution)
                {
                    await Console.Out.WriteLineAsync("---------------------------------------------------");
                    await Console.Out.WriteLineAsync("Request Number: " + solution.RequestId);
                    await Console.Out.WriteLineAsync("Solution ID: " + solution.SolutionId);
                    await Console.Out.WriteLineAsync("Description: " + solution.SolutionDescription);
                    await Console.Out.WriteLineAsync("Solved Date: " + solution.SolvedDate);
                    await Console.Out.WriteLineAsync("Solved By: " + solution.SolvedBy);
                    await Console.Out.WriteLineAsync("Comments: " + solution.RequestRaiserComment);
                    await Console.Out.WriteLineAsync("---------------------------------------------------");
                }
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
            
        }

        public async Task RespondToSolution(int ID)
        {
            await Console.Out.WriteLineAsync("Enter Solution ID:");
            int id = inputOperations.GetIntInput();
            await Console.Out.WriteLineAsync("Enter Comments:");
            string comments = inputOperations.GetStringInput();
            try
            {
                RequestSolution requestSolution = await requestSolutionBL.RespondToSolution(id, comments, ID);
                if (requestSolution != null)
                {
                    await Console.Out.WriteLineAsync("Solution Updated successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
        }

        public async Task ProvideSolution(int Id)
        {
            RequestSolution solution = new RequestSolution();
            int id;

            await Console.Out.WriteLineAsync("Enter Solution Description:");
            solution.SolutionDescription = inputOperations.GetStringInput();
            solution.SolvedDate = DateTime.Now;
            solution.SolvedBy = Id;
            await Console.Out.WriteLineAsync("Enter Request ID:");
            id = inputOperations.GetIntInput();
            solution.RequestId = id;

            try
            {
                RequestSolution requestSolution = await requestSolutionBL.GiveSolution(solution);

                if (requestSolution != null)
                {
                    await Console.Out.WriteLineAsync("Solution Added successfully!");
                }
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
           
        }
    }
}
