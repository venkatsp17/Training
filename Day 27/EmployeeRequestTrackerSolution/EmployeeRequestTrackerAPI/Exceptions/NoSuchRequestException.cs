namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoSuchRequestException : Exception
    {
        string message;
        public NoSuchRequestException()
        {
            message = "No such request present";
        }

        public override string Message => message;
    }
}
