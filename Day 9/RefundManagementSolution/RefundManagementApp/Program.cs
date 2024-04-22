using RefundManagementBL;
using RefundManagementBL.Exceptions.EmployeeExceptions;
using RefundManagementBL.Exceptions.ExpenseExceptions;
using RefundManagementBL.Exceptions.GeneralExceptions;
using RefundManagementModelLibrary;
using System.Globalization;
using System.Xml.Linq;

namespace RefundManagementApp
{
    public class Program
    {
        EmployeeBL employeeBL;
        ExpenseBL expenseBL;
        public Program() {
            employeeBL = new EmployeeBL();
            expenseBL = new ExpenseBL();
        }
        int GetIntInput()
        {
            int inp;
            while(!int.TryParse(Console.ReadLine(), out inp))
            {
                Console.WriteLine("Invalid Input. Try Again!");
            }
            return inp;
        }

        double GetDoubleInput()
        {
            double inp;
            while (!double.TryParse(Console.ReadLine(), out inp))
            {
                Console.WriteLine("Invalid Input. Try Again!");
            }
            return inp;
        }

        string GetStringInput()
        {
            string inp;
            do
            {
                inp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inp))
                {
                    Console.WriteLine("Invalid Input. Try Again!");
                }
            } while (string.IsNullOrWhiteSpace(inp));
            return inp;
        }
        void Menu()
        {
            Console.WriteLine("\n1. Add Employee");
            Console.WriteLine("2. Print All Employees");
            Console.WriteLine("3. Get Employee By ID");
            Console.WriteLine("4. Get Employee Name / Department");
            Console.WriteLine("5. Update Employee Salary / Name");
            Console.WriteLine("6. Delete Employee By ID");
           // Console.WriteLine("7. Can Access Expense ?");
            Console.WriteLine("7. Add Expense");
            Console.WriteLine("8. Print All Expenses");
            Console.WriteLine("9. Get All Expense By Employee ID");
            Console.WriteLine("10. Get Expense by ID");
            Console.WriteLine("11. Get All Expense By Type");
            Console.WriteLine("12. Review Expense\n");
        }
        void RefundManagement()
        {
           
            int choice;
            do
            {

                Menu();
                Console.WriteLine("\nEnter choice:");
                choice = GetIntInput();
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Signout");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        GetEmployeeByID();
                        break;
                    case 4:
                        GetEmployeeNameDepartment();
                        break;
                    case 5:
                        UpdateEmployeeSalaryName();
                        break;
                    case 6:
                        DeleteEmployeeByID();
                        break;
                    case 7:
                        AddExpense();
                        break;
                    case 8:
                        PrintAllExpenses();
                        break;
                    case 9:
                        GetAllExpenseByEmployeeID();
                        break;
                    case 10:
                        GetExpenseByID();
                        break;
                    case 11:
                        GetAllExpenseByType();
                        break;
                    case 12:
                        ReviewExpense();
                        break;
                }
            } while (choice != 0);
        }

        void AddEmployee()
        {
            string name;
            string department;
            double salary;


            Console.WriteLine("Enter Employee Name:");
            name = GetStringInput();
            Console.WriteLine("Enter Employee Department:");
            department = GetStringInput();
            Console.WriteLine("Enter Employee Salary:");
            salary = GetDoubleInput();
            try
            {
                Employee employee = new Employee(name, department, salary);
                int id = employeeBL.AddEmployee(employee);
                Console.WriteLine("Employee Added Succesfully!");
                Console.WriteLine("Employee ID: "+id);

            }
            catch (DuplicateEmployeeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void PrintAllEmployees()
        {
            Console.WriteLine("Employee Details:");
            try
            {
                employeeBL.GetAllEmployees().ForEach(e => Console.WriteLine(e.ToString()));
            }
            catch(NoDataAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void GetEmployeeByID()
        {
            Console.WriteLine("Enter Employee ID:");
            int id = GetIntInput();
            try
            {
                Employee emp = employeeBL.GetEmployeeById(id);
                Console.WriteLine("Employee " + id + " Detail:");
                Console.WriteLine(emp.ToString());
            }
            catch (EmployeeNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void GetEmployeeNameDepartment()
        {
            Console.WriteLine("a. Employee Name");
            Console.WriteLine("b. Employee Department");
            Console.WriteLine("Choose the value you want get");
            string inp = GetStringInput();
            string res;
            try
            {
                if (inp == "a")
                {
                    Console.WriteLine("Enter Employee ID:");
                    int id = GetIntInput();
                    res = employeeBL.GetEmployeeName(id);
                    Console.WriteLine("Employee Name: " + res);
                }
                else if(inp == "b") {
                    Console.WriteLine("Enter Employee ID:");
                    int id = GetIntInput();
                    res = employeeBL.GetEmployeeDepartment(id);
                    Console.WriteLine("Employee Department: " + res);
                }
                else
                {
                    Console.WriteLine("Choose Valid Option");
                }
            }
            catch (EmployeeNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void UpdateEmployeeSalaryName()
        {
            Console.WriteLine("a. Update Employee Name");
            Console.WriteLine("b. Update Employee Salary");
            Console.WriteLine("Choose the value you want get");
            string inp = GetStringInput();
            Console.WriteLine("Enter Employee ID:");
            int id = GetIntInput();
            string res;
            try
            {
                if (inp == "a")
                {
                    Console.WriteLine("Enter the New Name:");
                    string newName = GetStringInput();
                    Employee emp = employeeBL.UpdateEmployeeName(newName, id);
                    Console.WriteLine(emp.ToString());
                }
                else if (inp == "b")
                {
                    Console.WriteLine("Enter the New Salary:");
                    double salary = GetDoubleInput();
                    Employee emp = employeeBL.UpdateEmployeeSalaryById(id, salary);
                    Console.WriteLine(emp.ToString());
                }
                else
                {
                    Console.WriteLine("Choose Valid Option");
                }
            }
            catch (EmployeeNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void DeleteEmployeeByID()
        {
            Console.WriteLine("Enter Employee ID:");
            int id = GetIntInput();
            try
            {
                Employee emp = employeeBL.DeleteEmployeeByID(id);
                Console.WriteLine(emp.ToString());
                Console.WriteLine("Employee " + id + " Deleted");
            }
            catch (EmployeeNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void AddExpense()
        {
            int id;
            string type;
            string desc;
            double amt;

            Console.WriteLine("Enter Employee ID:");
            id = GetIntInput();
            Employee employee = new Employee();
            try
            {
                employee = employeeBL.GetEmployeeById(id); 
            }
            catch(EmployeeNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try Again.");
                return;
            }


            Console.WriteLine("Enter Expense Type:");
            type = GetStringInput();
            Console.WriteLine("Enter Expense Description:");
            desc = GetStringInput();
            Console.WriteLine("Enter Expense Amount:");
            amt = GetDoubleInput();
            try
            {
                Expense expense = new Expense(employee, type, desc, amt);
                int eid = expenseBL.AddExpense(expense);

            }
            catch (DuplicateExpenseException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void PrintAllExpenses()
        {
            Console.WriteLine("Expense Details:");
            try
            {
                expenseBL.GetAllExpenses().ForEach(e => Console.WriteLine(e.ToString()));
            }
            catch (NoDataAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void GetAllExpenseByEmployeeID()
        {
            int id;
            Console.WriteLine("Enter Employee ID:");
            id = GetIntInput();
            Console.WriteLine("Expense Details of Employee "+id);
            try
            {
                expenseBL.GetAllExpensesByEmployeeId(id).ForEach(e => Console.WriteLine(e.ToString()));
            }
            catch (NoDataAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void GetExpenseByID()
        {
            Console.WriteLine("Enter Expense ID:");
            int id = GetIntInput();
            try
            {
                Expense exp = expenseBL.GetExpenseById(id);
                Console.WriteLine("Expense " + id + " Detail:");
                Console.WriteLine(exp.ToString());
            }
            catch (ExpenseNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        void GetAllExpenseByType ()
        {
            string type;
            Console.WriteLine("Enter Expense Type:");
            type = GetStringInput();
            Console.WriteLine("Expense Details of Type " + type);
            try
            {
                expenseBL.GetAllExpensesByType(type).ForEach(e => Console.WriteLine(e.ToString()));
            }
            catch (NoDataAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void ReviewExpense()
        {
            int id;
            Console.WriteLine("Enter Employee ID:");
            id = GetIntInput();
            try
            {
                if (employeeBL.CanAuthorizeExpense(id))
                {
                    string inp;
                    bool appro;
                    string reason;
                    int eid;
                    Console.WriteLine("Enter Expense ID:");
                    eid = GetIntInput();
                    Console.WriteLine("Enter true/false to Approve Expense");
                    inp = GetStringInput();
                    if (inp == "true")
                    {
                        appro = true;
                        reason = "";
                    }
                    else if (inp == "false")
                    {
                        appro = false;
                        Console.WriteLine("Enter Refusal Reason:");
                        reason = GetStringInput();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry, Try again.");
                        return;
                    }
                    Expense expense = expenseBL.ApproveRefuseExpense(appro, reason, eid);
                    Console.WriteLine(expense.ToString());
                }
                else
                {
                    Console.WriteLine("Access Denied!");
                }
            }
            catch (AccessDeniedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ExpenseNotFoundException e)
            {
                Console.WriteLine(e.Message);   
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();    
            program.RefundManagement();
        }
    }
}
