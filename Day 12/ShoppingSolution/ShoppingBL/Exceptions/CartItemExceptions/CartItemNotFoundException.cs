using System.Runtime.Serialization;

namespace ShoppingBL.Exceptions.CartItemExceptions
{
    public class CartItemNotFoundException : Exception
    {
        string message;
        public CartItemNotFoundException()
        {
            message = "Cart Item Not Found!";
        }
        public override string Message => message;
    }
}