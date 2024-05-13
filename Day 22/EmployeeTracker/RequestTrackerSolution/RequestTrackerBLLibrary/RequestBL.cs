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
            try
            {
                var result = await _RequestRepository.Get(requestNumber);
                result.ClosedDate = DateTime.Now;
                result.RequestClosedBy = Id;
                return await _RequestRepository.Update(result);
            }
            catch (Exception ex)
            {
                throw new Exception("No Request Found!");
            }
        }

        public async Task<Request> GetRequestById(int Id)
        {
            try
            {
                var result = await _RequestRepository.Get(Id);
                return result;
            }
            catch
            {
                throw new Exception("Error Getting Request!");
            }
        }

        public async Task<Request> RaiseRequest(Request request)
        {
            try
            {
                var result = await _RequestRepository.Add(request);
                return result;
            }
            catch(Exception ex) {
                throw new Exception("Failed to Add Request!", ex);
            }
            
        }

        public async Task<ICollection<Request>> ViewRequestStatus(int EmployeeID)
        {
            try
            {
                var result = await _EmployeeRequestRepository.Get(EmployeeID);
                return result.RequestsRaised;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Load Requests!");
            }
            
        }

        public async Task<IList<Request>> ViewRequestStatusAdmin()
        {
            try
            {
                var result = await _RequestRepository.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Load Requests!");
            }

        }
    }
}
