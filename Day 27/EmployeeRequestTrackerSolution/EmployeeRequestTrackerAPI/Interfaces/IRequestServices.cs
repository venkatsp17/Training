using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestServices
    {
        public Task<Request> RaiseRequest(RaiseRequestDTO raiseRequestDTO);

        public Task<IEnumerable<Request>> GetAllOpenRequest(int id);
    }
}
