using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestServices
    {
        public Task<Request> RaiseRequest(Request request);

        public Task<ICollection<Request>> ViewRequestStatus(int EmployeeID);

        public Task<Request> CloseRequest(int requestNumber, int Id);

        public Task<IList<Request>> ViewRequestStatusAdmin();

        public Task<Request> GetRequestById(int Id);

    }
}
