using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBL.Exceptions.EmployeeExceptions
{
    public class DuplicateEmployeeException : Exception
    {
        string msg;
        public DuplicateEmployeeException()
        {

            msg = "Employee Already Exists";
        }
        public override string Message => msg;
    }
}
