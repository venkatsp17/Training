namespace PizzaShopAPI.Exceptions
{
    public class UnableToRegisterException : Exception
    {
        string message; public UnableToRegisterException(string message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
