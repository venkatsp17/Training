using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface SolutionFeedbackServices
    {
        public Task<SolutionFeedback> GiveFeedbackOnSolution(SolutionFeedback feedback);

    }
}
