namespace PizzaShopAPI.Exceptions
{
    public class PizzaOutOfStockException : Exception
    {
        string message;
        public PizzaOutOfStockException(string message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
