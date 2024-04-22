using RefundManagementBL.Exceptions.EmployeeExceptions;
using RefundManagementBL.Exceptions.ExpenseExceptions;
using RefundManagementBL.Exceptions.GeneralExceptions;
using RefundManagementDAL;
using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBL
{
    public class ExpenseBL: IExpenseServices
    {
        readonly IRepository<int, Expense> _expenseRepository;
        public ExpenseBL() { 
            _expenseRepository = new ExpenseRepository();
        }

        public int AddExpense(Expense expense)
        {
            var result = _expenseRepository.Add(expense);

            if (result != null)
            {
                return result.ExpenseId;
            }
            throw new DuplicateExpenseException();
        }

        public Expense DeleteExpense(int expenseId)
        {
            var expense = _expenseRepository.Get(expenseId);
            if (expense != null)
            {
                _expenseRepository.Delete(expenseId);
            }
            throw new ExpenseNotFoundException();
        }

        public List<Expense> GetAllExpenses()
        {
            var expenses = _expenseRepository.GetAll();
            if (expenses != null)
            {
                return new List<Expense>(expenses);
            }
            throw new NoDataAvailableException();
        }

        public List<Expense> GetAllExpensesByEmployeeId(int employeeId)
        {
            var expenses = _expenseRepository.GetAll();
            List<Expense> result = new List<Expense>();
            if (expenses != null)
            {
                foreach (var expense in expenses)
                {
                    if (expense.Employee.EmployeeId == employeeId)
                    {
                        result.Add(expense);
                    }
                }
                return result;
            }
            throw new NoDataAvailableException();
        }

        public List<Expense> GetAllExpensesByType(string type)
        {
            var expenses = _expenseRepository.GetAll();
            List<Expense> result = new List<Expense>();
            if (expenses != null)
            {
                foreach (var expense in expenses)
                {
                    if (expense.ExpenseType == type)
                    {
                        result.Add(expense);
                    }
                }
                return result;
            }
            throw new NoDataAvailableException();
        }

        public Expense GetExpenseById(int expenseId)
        {
            var expense = _expenseRepository.Get(expenseId);
            if (expense != null)
            {
                return expense;
            }
            throw new ExpenseNotFoundException();
        }

        public Expense ApproveRefuseExpense(bool IsApproved, string RefusalReason, int expenseId)
        {
            var expense = _expenseRepository.Get(expenseId);
            if (expense != null)
            {
                expense.IsApproved = IsApproved;
                expense.RefusalReason = RefusalReason;
                return _expenseRepository.Update(expense);
            }
            throw new ExpenseNotFoundException();
        }
    }
}
