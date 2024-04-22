using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBL.Exceptions.ExpenseExceptions
{
    public class DuplicateExpenseException : Exception
    {
        string msg;
        public DuplicateExpenseException()
        {

            msg = "Expense Already Exists";
        }
        public override string Message => msg;
    }
}
