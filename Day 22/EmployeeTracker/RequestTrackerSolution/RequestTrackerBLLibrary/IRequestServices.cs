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

        public Task<Request> ViewRequestStatus(int EmployeeID);

        public Task<Request> CloseRequest(Request request, int closedBy, DateTime date);
    }
}
