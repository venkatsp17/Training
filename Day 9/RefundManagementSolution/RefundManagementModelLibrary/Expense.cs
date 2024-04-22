using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RefundManagementModelLibrary
{
    public class Expense
    {
        public Employee Employee { get; set; } = new Employee();
        public int ExpenseId { get; set; }
        public string ExpenseType { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public bool IsApproved { get; set; }
        public string RefusalReason { get; set; }

        public Expense()
        {
            Employee = new Employee();
            ExpenseId = 0;
            ExpenseType = string.Empty;
            Date = DateTime.Now;
            Description = string.Empty;
            Amount = 0;
        }

        public Expense(Employee employee, int expenseId, string expenseType, DateTime date, string description, double amount)
        {
            Employee = employee;
            ExpenseId = expenseId;
            ExpenseType = expenseType;
            Date = date;
            Description = description;
            Amount = amount;
        }

        public override string ToString()
        {
            return "\nEmployee Id       : " + Employee.EmployeeId
                + "\nEmployee Name      : " + Employee.Name
                + "\nExpense Id         : " + ExpenseId
                + "\nExpense Type       : " + ExpenseType
                + "\nDate of Expense    : " + Date
                + "\nDescription        : " + Description
                + "\nAmount             : " + Amount;
        }
    }


}
