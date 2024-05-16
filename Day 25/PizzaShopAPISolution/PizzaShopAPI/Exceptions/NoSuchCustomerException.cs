namespace PizzaShopAPI.Exceptions
{
    public class NoSuchCustomerException : Exception
    {
        string message;
        public NoSuchCustomerException() {
            message = "No Customer Found!";
        }
        public override string Message => message;
    }
}
