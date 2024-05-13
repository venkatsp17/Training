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
            try
            {
                return await _solutionRepository.Get(Id);
            }
            catch
            {
                throw new Exception("Error Getting Solution!");
            }


        }

        public async Task<RequestSolution> GiveSolution(RequestSolution solution)
        {
            try
            {
                return await _solutionRepository.Add(solution);
            }
            catch
            {
                throw new Exception("Error Adding Solution!");
            }


        }

        public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
        {
            try
            {
                return await _solutionRepository.Add(solution);
            }
            catch
            {
                throw new Exception("Error Adding Solution");
            }
        }

        public async Task<RequestSolution> RespondToSolution(int solutionId, string comments)
        {

            try
            {
                RequestSolution requestSolution = await _solutionRepository.Get(solutionId);
                requestSolution.RequestRaiserComment = comments;
                return await _solutionRepository.Update(requestSolution);
            }
            catch
            {
                throw new Exception("Error Updating Solution!");
            }
        }

        public async Task<Request> ViewAllRequestSolutions(int Id)
        {
            try
            {
                return await _repository.Get(Id);
            }
            catch {
                throw new Exception("No Solutions Available!");
            }

           
        }

        public async Task<IList<RequestSolution>> ViewAllRequestSolutionsAdmin()
        {
            try
            {
                return await _solutionRepository.GetAll();
            }
            catch
            {
                throw new Exception("No Solutions Available!");
            }
        }


    }
}
