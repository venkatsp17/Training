using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class SolutionRepository : IRepository<int, RequestSolution>
    {
        protected readonly RequestTrackerContext _context;
        public SolutionRepository(RequestTrackerContext context) {
            _context = context;
        }

        public async virtual Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<RequestSolution> Delete(int key)
        {
            var solution = await Get(key);
            if (solution != null)
            {
                _context.RequestSolutions.Remove(solution);
                await _context.SaveChangesAsync();
            }
            return solution;
        }

        public async virtual Task<RequestSolution> Get(int key)
        {

            var solution = _context.RequestSolutions.SingleOrDefault(s => s.SolutionId == key);
            return solution;
        }

        public async virtual Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async virtual Task<RequestSolution> Update(RequestSolution entity)
        {
            var solution = await Get(entity.SolutionId);
            if (solution != null)
            {
                _context.Entry<RequestSolution>(solution).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return solution;
        }
    }
}
