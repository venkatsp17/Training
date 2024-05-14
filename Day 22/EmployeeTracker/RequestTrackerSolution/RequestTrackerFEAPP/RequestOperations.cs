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

            request.RequestStatus = "Open";

            request.RequestClosedBy = 101;
            try
            {
                Request raised = await requestBL.RaiseRequest(request);
                if (raised != null)
                {
                    Console.WriteLine("Request Raised successfully! Id:" + raised.RequestNumber);

                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
        }

        public async Task ViewAllRequestStatus(int Id)
        {
            try
            {
                ICollection<Request> requests = await requestBL.ViewRequestStatus(Id);
                foreach (Request request in requests)
                {
                    await Console.Out.WriteLineAsync("---------------------------------------------------");
                    await Console.Out.WriteLineAsync("Request Number: " + request.RequestNumber);
                    await Console.Out.WriteLineAsync("Message: " + request.RequestMessage);
                    await Console.Out.WriteLineAsync("Raised By: " + request.RequestRaisedBy);
                    await Console.Out.WriteLineAsync("Status: " + request.RequestStatus);
                    await Console.Out.WriteLineAsync("Request Date: " + request.RequestDate);
                    await Console.Out.WriteLineAsync("---------------------------------------------------");
                }
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
            
           

        }

        public async Task ViewAllRequestStatusAdmin()
        {

            try
            {
                IList<Request> requests = await requestBL.ViewRequestStatusAdmin();

                foreach (Request request in requests)
                {
                    await Console.Out.WriteLineAsync("---------------------------------------------------");
                    await Console.Out.WriteLineAsync("Request Number: " + request.RequestNumber);
                    await Console.Out.WriteLineAsync("Message: " + request.RequestMessage);
                    await Console.Out.WriteLineAsync("Raised By: " + request.RequestRaisedBy);
                    await Console.Out.WriteLineAsync("Status: " + request.RequestStatus);
                    await Console.Out.WriteLineAsync("Request Date: " + request.RequestDate);
                    await Console.Out.WriteLineAsync("---------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
            

        }

        public async Task UpdateClosed(int EmployeeId)
        {
            int id;
            await Console.Out.WriteLineAsync("Enter Request ID:");
            id = inputOperations.GetIntInput();

            try
            {
                Request request = await requestBL.CloseRequest(id, EmployeeId);
                if (request != null)
                {
                    await Console.Out.WriteLineAsync("Request Updated successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
           
        }
    }
}
