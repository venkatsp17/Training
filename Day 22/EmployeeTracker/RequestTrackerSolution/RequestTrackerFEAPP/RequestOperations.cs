using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class RequestOperations
    {
        RequestBL requestBL;
        InputOperations inputOperations;
        EmployeeBL employeeBL;
        public RequestOperations() { 
            requestBL = new RequestBL();
            inputOperations = new InputOperations();
            employeeBL = new EmployeeBL();
        }
        public async Task RaiseNewRequest(int Id)
        {
            Request request = new Request();
            EmployeeBL employeeBL = new EmployeeBL();

            Console.WriteLine("Enter the message:");
            request.RequestMessage = inputOperations.GetStringInput();

            request.RequestDate = DateTime.Now;
            request.RequestRaisedBy = Id;

            request.RequestStatus = "Initiated";

            request.RequestClosedBy = 101;
            
            Request raised = await requestBL.RaiseRequest(request);
            if(raised != null)
            {
                Console.WriteLine("Request Raised successfully!");

            }
            else
            {
                Console.WriteLine("Error Raising request!");
            }
        }

        public async Task ViewAllRequestStatus(int Id)
        {

            ICollection<Request> requests = await requestBL.ViewRequestStatus(Id);
            await Console.Out.WriteLineAsync("Message\t\t\t\tDate\t\tRaisedBy\t\tStatus");
            foreach (Request request in requests)
            {
                await Console.Out.WriteLineAsync(request.RequestMessage+"\t\t\t\t"+request.RequestDate+"\t\t"+request.RequestRaisedBy+"\t\t"+request.RequestStatus);
            }

        }

        public async Task ViewAllRequestStatusAdmin()
        {

            IList<Request> requests = await requestBL.ViewRequestStatusAdmin();
            await Console.Out.WriteLineAsync("Message\t\tDate\t\tRaisedBy\t\tStatus");
            foreach (Request request in requests)
            {
                await Console.Out.WriteLineAsync(request.RequestMessage + "\t\t" + request.RequestDate + "\t\t" + request.RequestRaisedBy + "\t\t" + request.RequestStatus);
            }

        }

        public async Task UpdateClosed(int EmployeeId)
        {
            int id;
            await Console.Out.WriteLineAsync("Enter Request ID:");
            id = inputOperations.GetIntInput();
            Request request = await requestBL.CloseRequest(id, EmployeeId);
            if (request != null)
            {
                await Console.Out.WriteLineAsync("Request Updated successfully!");
            }
        }
    }
}
