using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestServices
    {
        private readonly IRepository<int, Request> _RequestRepository;
        private readonly IRepository<int, Employee> _EmployeeRequestRepository;

        public RequestBL()
        {
            IRepository<int, Employee> EmployeeRepo = new EmployeeRequestRepository(new RequestTrackerContext());
            IRepository<int, Request> RequestRepo = new RequestRepository(new RequestTrackerContext());
            _EmployeeRequestRepository = EmployeeRepo;
            _RequestRepository = RequestRepo;
        }
        public async Task<Request> CloseRequest(int requestNumber, int Id)
        {
                var result = await _RequestRepository.Get(requestNumber);
                if (result != null)
                {
                    result.ClosedDate = DateTime.Now;
                    result.RequestClosedBy = Id;
                    result.RequestStatus = "Closed";
                    return await _RequestRepository.Update(result);
                }
            throw new Exception("No Request Found!");
        }

        public async Task<Request> GetRequestById(int Id)
        {
            var result = await _RequestRepository.Get(Id);
            if (result != null)
            {
                return result;
            }
            throw new Exception("Error Getting Request!");
        }

        public async Task<Request> RaiseRequest(Request request)
        {
             var result = await _RequestRepository.Add(request);
             if(result != null) {
                  return result;
              }
            throw new Exception("Failed to Add Request!");
        }

        public async Task<ICollection<Request>> ViewRequestStatus(int EmployeeID)
        {
             var result = await _EmployeeRequestRepository.Get(EmployeeID);
             if(result != null)
             {
                    return result.RequestsRaised;
             }
             throw new Exception("Failed to Load Requests!");
        }

        public async Task<IList<Request>> ViewRequestStatusAdmin()
        {
            var result = await _RequestRepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new Exception("Failed to Load Requests!");
        }
    }
}
