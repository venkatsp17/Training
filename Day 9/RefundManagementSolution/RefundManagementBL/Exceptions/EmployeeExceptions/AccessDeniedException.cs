using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBL.Exceptions.EmployeeExceptions
{
    public class AccessDeniedException: Exception
    {
        string msg;
        public AccessDeniedException()
        {

            msg = "Access Not Allowed";
        }
        public override string Message => msg;
    }
}
