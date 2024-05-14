namespace EmployeeAPIApp.Exceptions
{
    public class NoEmployeeFoundException : Exception
    {
        string message;
        public NoEmployeeFoundException() 
        {
            message = "No Employee Found!";
        }

        public override string Message => message;

    }
}
