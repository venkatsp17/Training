using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestSolutionServices
    {
        public Task<Request> ViewAllRequestSolutions(int Id);

        public Task<RequestSolution> RespondToSolution(int solutionId, string comments);

        public Task<IList<RequestSolution>> ViewAllRequestSolutionsAdmin();

        public Task<RequestSolution> GetSolutionByID(int ID);

        public Task<RequestSolution> ProvideSolution(RequestSolution solution);

        public Task<RequestSolution> GiveSolution(RequestSolution solution);
    }
}
