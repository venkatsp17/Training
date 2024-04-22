using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBL.Exceptions.ExpenseExceptions
{
    public class ExpenseNotFoundException: Exception
    {
        string msg;
        public ExpenseNotFoundException()
        {
            msg = "Expense Not Found";
        }
        public override string Message => msg;
    }
}
