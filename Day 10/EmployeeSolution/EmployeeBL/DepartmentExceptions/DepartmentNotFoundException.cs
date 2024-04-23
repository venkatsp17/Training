using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary.Exceptions
{
    public class DepartmentNotFoundException: Exception
    {
        string msg;
        public DepartmentNotFoundException()
        {
            msg = "Department Not Found";
        }
        public override string Message => msg;
    }
}
