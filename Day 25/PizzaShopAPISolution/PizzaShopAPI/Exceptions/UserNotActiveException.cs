namespace PizzaShopAPI.Exceptions
{
    public class UserNotActiveException : Exception
    {
        string message;
        public UserNotActiveException(string message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
