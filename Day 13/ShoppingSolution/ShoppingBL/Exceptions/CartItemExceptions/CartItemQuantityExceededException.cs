using System.Runtime.Serialization;

namespace ShoppingBL.Exceptions.CartItemExceptions
{
    [Serializable]
    public class CartItemQuantityExceededException : Exception
    {
        string message;
        public CartItemQuantityExceededException()
        {
            message = "CartItem Quantity Exceeded!";
        }
        public override string Message => message;
    }
}