using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoDataAvailableException : Exception
    {
        string message;
        public NoDataAvailableException()
        {
            message = "No Data Available!";
        }
        public override string Message => message;
    }
}
