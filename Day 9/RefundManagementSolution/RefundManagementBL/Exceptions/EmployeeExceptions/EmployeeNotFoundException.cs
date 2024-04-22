﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBL.Exceptions.EmployeeExceptions
{
    public class EmployeeNotFoundException : Exception
    {
        string msg;
        public EmployeeNotFoundException()
        {
            msg = "Employee Not Found";
        }
        public override string Message => msg;
    }
}
