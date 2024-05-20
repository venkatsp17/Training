namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NotLoggedInException : Exception
    {
        string message;
        public NotLoggedInException() {
            message = "User Not logged In";
        }
        public override string Message => message;
    }
}
