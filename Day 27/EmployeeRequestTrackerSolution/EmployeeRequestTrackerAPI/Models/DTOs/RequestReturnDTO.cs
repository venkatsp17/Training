namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class RequestReturnDTO
    {
        public int RequestId { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestStatus { get; set; }


        public int RequestRaisedById { get; set; }
    }
}
