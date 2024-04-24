using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary.Exceptions
{
    public class NoDataAvailableException: Exception
    {
        string msg;
        public NoDataAvailableException() {
            msg = "No Data Available";
        }
        public override string Message => msg;
    }
}
