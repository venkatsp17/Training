using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL.Exceptions
{
    public class CartNotFoundException : Exception
    {
        string message;
        public CartNotFoundException()
        {
            message = "Cart Not Found!";
        }
        public override string Message => message;
    }
}
