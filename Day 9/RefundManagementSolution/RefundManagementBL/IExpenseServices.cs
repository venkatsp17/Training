using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBL
{
    public interface IExpenseServices
    {
        int AddExpense(Expense expense);
        Expense GetExpenseById(int expenseId);
        List<Expense> GetAllExpenses();
        List<Expense> GetAllExpensesByType(string type);
        List<Expense> GetAllExpensesByEmployeeId(int employeeId);
        Expense ApproveRefuseExpense(bool IsApproved, string RefusalReason, int employeeId);
        Expense DeleteExpense(int expenseId);
    }
}
