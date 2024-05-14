using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionFeedbackBL : SolutionFeedbackServices
    {
        private readonly IRepository<int, SolutionFeedback> feedbackRepository;
        private readonly IRepository<int, RequestSolution> solutionRepository;
        private readonly IRepository<int, Request> requestRepository;
        public SolutionFeedbackBL() {
            IRepository<int, SolutionFeedback> repo = new FeedBackRepository(new RequestTrackerContext());
            IRepository<int, RequestSolution> repo1 = new SolutionRepository(new RequestTrackerContext());
            IRepository<int, Request> repo2 = new RequestRepository(new RequestTrackerContext());
            feedbackRepository = repo;
            solutionRepository = repo1;
            requestRepository = repo2;
        }

        public async Task<SolutionFeedback> GiveFeedbackOnSolution(SolutionFeedback feedback)
        {
                var solution = await solutionRepository.Get(feedback.SolutionId); 
                if(solution!=null)
                {
                var request = await requestRepository.Get(solution.RequestId);
                if (request != null)
                {
                    if(request.RequestRaisedBy == feedback.FeedbackBy)
                    {
                        var result = await feedbackRepository.Add(feedback);
                        if (result != null)
                        {
                            return result;
                        }
                        throw new Exception("Error Adding Feedback!");
                    }
                    throw new Exception("User Operation Not Allowed!");
                }
                throw new Exception("Error Adding Feedback!");
            }
            throw new Exception("Error Adding Feedback!");
        }
    }
}
