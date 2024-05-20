using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        protected readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> Delete(int key)
        {
            var request = await Get(key);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return request;
        }

        public async virtual Task<Request> Get(int key)
        {
            var request = _context.Requests.SingleOrDefault(r => r.RequestId == key);
            return request;
        }

        public async Task<IEnumerable<Request>> Get()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            var request = await Get(entity.RequestId);
            if (request != null)
            {
                _context.Entry<Request>(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return request;
        }

    }
}
