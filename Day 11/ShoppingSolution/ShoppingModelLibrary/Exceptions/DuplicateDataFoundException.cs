using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class DuplicateDataFoundException: Exception
    {
        string message;
        public DuplicateDataFoundException()
        {
            message = "Duplicate Data Found!";
        }
        public override string Message => message;
    }
}
