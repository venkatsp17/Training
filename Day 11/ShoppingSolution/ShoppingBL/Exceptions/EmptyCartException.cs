using System.Runtime.Serialization;

namespace ShoppingBL.Exceptions
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