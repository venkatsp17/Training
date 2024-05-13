using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class FeedBackRepository : IRepository<int, SolutionFeedback>
    {

        protected readonly RequestTrackerContext _context;

        FeedBackRepository(RequestTrackerContext context)
        {
           _context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<SolutionFeedback> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<SolutionFeedback> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IList<SolutionFeedback>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            throw new NotImplementedException();
        }
    }
}
