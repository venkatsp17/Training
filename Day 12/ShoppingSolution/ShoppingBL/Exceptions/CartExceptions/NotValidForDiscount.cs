using System.Runtime.Serialization;

namespace ShoppingBL.Exceptions.CartExceptions
{
    public class NotValidForDiscount : Exception
    {
        string message;
        public NotValidForDiscount()
        {
            message = "Not Valid For Discount";
        }
        public override string Message => message;
    }
}