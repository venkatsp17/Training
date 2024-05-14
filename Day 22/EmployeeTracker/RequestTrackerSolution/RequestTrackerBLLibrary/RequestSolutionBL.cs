using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestSolutionBL : IRequestSolutionServices
    {
        private readonly IRepository<int, Request> _repository;
        private readonly IRepository<int, RequestSolution> _solutionRepository;
        public RequestSolutionBL() {
            IRepository<int, Request> repo = new RequestSolutionRepository(new RequestTrackerContext());
            _repository = repo;
            _solutionRepository = new SolutionRepository(new RequestTrackerContext());
        }

        public async Task<RequestSolution> GetSolutionByID(int Id)
        {
                var result = await _solutionRepository.Get(Id);
                if (result != null) {
                    return result;
                }
            throw new Exception("Error Getting Solution!");
        }

        public async Task<RequestSolution> GiveSolution(RequestSolution solution)
        {

            var result = await _solutionRepository.Add(solution);
            if (result != null)
            {
                return result;
            } 
            throw new Exception("Error Adding Solution!");

        }

        public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
        {
            var result = await _solutionRepository.Add(solution);
            if (result != null)
            {
                return result;
            }
            throw new Exception("Error Adding Solution!");
        }

        public async Task<RequestSolution> RespondToSolution(int solutionId, string comments, int EmpID)
        {
            RequestSolution requestSolution = await _solutionRepository.Get(solutionId);
            if (requestSolution != null)
            {
                var request = await _repository.Get(requestSolution.RequestId);
                if(request != null)
                {
                    if(request.RequestRaisedBy == EmpID)
                    {
                        requestSolution.RequestRaiserComment = comments;
                        var result = await _solutionRepository.Update(requestSolution);
                        if (result != null)
                        {
                            return result;
                        }
                        throw new Exception("Error Updating Solution!");
                    }
                    throw new Exception("User Operation not allowed!");
                }
                throw new Exception("Error Updating Solution!");
            }
            throw new Exception("Error Updating Solution!");

        }

        public async Task<Request> ViewAllRequestSolutions(int Id)
        {
                var result = await _repository.Get(Id);
                if(result!= null)
                {
                    return result;
                }
            throw new Exception("No Solutions Available!");
        }

        public async Task<IList<RequestSolution>> ViewAllRequestSolutionsAdmin()
        {
                var result =  await _solutionRepository.GetAll();
                if(result!= null)
                {
                    return result;
                }
                throw new Exception("No Solutions Available!");
        }

    }
}
