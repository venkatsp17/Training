using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedback: SolutionRepository
    {
        protected readonly RequestTrackerContext _context;

        public SolutionFeedback(RequestTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.Include(s => s.Feedbacks).ToListAsync();
        }
        public async override Task<RequestSolution> Get(int key)
        {
            var solution = _context.RequestSolutions.Include(s => s.Feedbacks).SingleOrDefault(e => e.SolutionId == key);
            return solution;
        }


    }
}
