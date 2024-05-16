namespace PizzaShopAPI.Exceptions
{
    public class NoSuchPizzaException : Exception
    {
        string message;
        public NoSuchPizzaException()
        {
            message = "No Pizza Found!";
        }
        public override string Message => message;
    }
}
