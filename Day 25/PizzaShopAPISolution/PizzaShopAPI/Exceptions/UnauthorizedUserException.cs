namespace PizzaShopAPI.Exceptions
{
    public class UnauthorizedUserException : Exception
    {
        string message;
        public UnauthorizedUserException(string message) {
           this.message = message;
    }
        public override string Message => message;
    }
}
