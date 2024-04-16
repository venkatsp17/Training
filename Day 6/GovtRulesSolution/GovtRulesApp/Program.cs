using CompanyModelClassLibrary;

namespace GovtRulesApp
{
    public class Program
    {
        Employee[] employees = new Employee[3];

        string GetStringInput()
        {
            string inp;
            do
            { 
                inp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inp))
                {
                    Console.WriteLine("Invalid Input! Try again..");
                }
            } while (string.IsNullOrWhiteSpace(inp));
            return inp;
        }

        double GetDoubleInput()
        {
            double inp;
            while (!(double.TryParse(Console.ReadLine(), out inp)))
            {
                Console.WriteLine("Invalid Entry! Try Again..");
            }
            return inp;

        }

        int GetIntInput()
        {
            int inp;
            while (!(int.TryParse(Console.ReadLine(), out inp)))
            {
                Console.WriteLine("Invalid Entry! Try Again..");
            }
            return inp;

        }

        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print All Employee Details");
            Console.WriteLine("3. Print Employee PF");
            Console.WriteLine("4. Print Employee Leave Details");
            Console.WriteLine("5. Print Employee Gratuity Amount");
            Console.WriteLine("0. Exit");
        }

        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployees();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        PrintEmployeePF();
                        break;
                    case 4:
                        PrintEmployeeLeaveDetails();
                        break;
                    case 5:
                        PrintEmployeeGratuity();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        Employee CreateEmployee(int id)
        {
            string name;
            string dept;
            string desig;
            string type;
            double salary;
            Employee employee = new Employee();

            Console.WriteLine("Enter Employee Name:");
            name = GetStringInput();
            Console.WriteLine("Enter Employee Department:");
            dept = GetStringInput();
            Console.WriteLine("Enter Employee Designation:");
            desig = GetStringInput();
            Console.WriteLine("Enter Employee Basic Salary:");
            salary = GetDoubleInput();
            Console.WriteLine("Please enter the COMPANY name:");
            type = GetStringInput();
            if (type == "XYZ")
                employee = new XYZ(101 + id, name, dept, desig, salary);
            else if (type == "ABC")
                employee = new ABC(101 + id, name, dept, desig, salary);
            return employee;
        }

        void AddEmployees()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }

        void PrintAllEmployees()
        {
            Console.WriteLine("=========================================");
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    employees[i].PrintAllEmployeeDetails();
                }
            }
            Console.WriteLine("=========================================");
        }

        void PrintEmployeePF()
        {
            Console.WriteLine("Enter Employee ID:");
            int id = GetIntInput();
            double salary = employees[id - 101].BasicSalary;
            double pf = employees[id - 101].EmployeePF(salary);
            Console.WriteLine($"Employee PF: {pf}");
        }

        void PrintEmployeeLeaveDetails()
        {
            Console.WriteLine("Enter Employee ID:");
            int id = GetIntInput();
            string leavedetails = employees[id-101].LeaveDetails();
            Console.WriteLine("=========================================");
            Console.WriteLine(leavedetails);
            Console.WriteLine("=========================================");
        }

        void PrintEmployeeGratuity()
        {
            Console.WriteLine("Enter Employee ID:");
            int id = GetIntInput();
            Console.WriteLine("Enter Service Years Completed:");
            int years = GetIntInput();
            double salary = employees[id - 101].BasicSalary;
            double gratuity = employees[id - 101].gratuityAmount(years,salary);
            Console.WriteLine($"Employee Gratuity Amount: {gratuity}");
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}
