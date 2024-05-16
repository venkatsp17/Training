namespace EmployeeAPIApp.Models
{
    public class ErrorModel
    {
        public string message { get; set; }
        public int statuscode { get; set; }
        public ErrorModel(string message, int statuscode)
        {
            this.message = message;
            this.statuscode = statuscode;
        }
    }
}
