using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeRequestTrackerAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }


        public int RequestRaisedById { get; set; }
        [JsonIgnore]
        public Employee RaisedByEmployee { get; set; }

        public int? RequestClosedById { get; set; }
        [JsonIgnore]
        public Employee RequestClosedByEmployee { get; set; }


    }
}
