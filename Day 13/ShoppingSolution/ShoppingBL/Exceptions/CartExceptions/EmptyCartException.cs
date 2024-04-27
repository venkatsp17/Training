using System.Runtime.Serialization;

namespace ShoppingBL.Exceptions.CartExceptions
{
    public class EmptyCartException : Exception
    {
        string message;
        public EmptyCartException()
        {
            message = "Cart is Empty";
        }
        public override string Message => message;
    }
}