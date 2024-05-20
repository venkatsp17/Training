using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Repositories;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestServices : IRequestServices
    {
        private readonly IRepository<int, Request> _RequestRepository;
        private readonly IRepository<int, Employee> _EmployeeRespository;

        public RequestServices(IRepository<int, Request> requestRepository, IRepository<int, Employee> employeeRepository)
        {
            _RequestRepository = requestRepository;
            _EmployeeRespository = employeeRepository;
        }
        public async Task<Request> RaiseRequest(RaiseRequestDTO raiseRequestDTO)
        {
            Request request = new Request();
            request.RequestMessage = raiseRequestDTO.RequestMessage;
            request.RequestDate = DateTime.Now;
            request.RequestStatus = "Open";
            request.RequestRaisedById = raiseRequestDTO.RequestRaisedById;
            var result = await _RequestRepository.Add(request);
             if(result != null) { 
                  return result;
              }
            throw new Exception("Failed to Add Request!");
        }

        public async Task<IEnumerable<Request>> GetAllOpenRequest(int id)
        {
                IEnumerable<Request> requests;
                var employee = await _EmployeeRespository.Get(id);
                if (employee == null)
                    throw new NoSuchEmployeeException();
                requests = await _RequestRepository.Get();
                if(requests == null)
                    throw new NoSuchRequestException();
                if (employee.Role == "Admin")
                {
                   
                }
                else
                {
                    requests = requests.Where(r => r.RequestRaisedById == employee.Id).ToList();
                }
                requests = requests.Where(r => r.RequestStatus == "Open").ToList();
                requests = requests.OrderBy(r => r.RequestDate).ToList();
                return requests;
            
        }
    }
}
