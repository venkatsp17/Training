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
        public SolutionFeedbackBL() {
            IRepository<int, SolutionFeedback> repo = new FeedBackRepository(new RequestTrackerContext());
            feedbackRepository = repo;
        }

        public Task<SolutionFeedback> GiveFeedbackOnSolution(SolutionFeedback feedback)
        {
            try
            {
                return feedbackRepository.Add(feedback);
            }
            catch {
                throw new Exception("Error Adding Feedback!");
            }
        }
    }
}
