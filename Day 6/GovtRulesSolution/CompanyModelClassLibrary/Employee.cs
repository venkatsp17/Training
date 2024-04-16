namespace CompanyModelClassLibrary
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public double BasicSalary { get; set; }

        //double EMPLOYER_CONTRIBUTION { get; set; }

        public Employee()
        {
            EmpID = 0;
            Name = string.Empty;
            Department = string.Empty;
            Designation = string.Empty;
            BasicSalary = 0.0;
        }

        public Employee(int empID, string name, string department, string designation, double basicSalary)
        {
            EmpID = empID;
            Name = name;
            Department = department;
            Designation = designation;
            BasicSalary = basicSalary;
        }

        public void PrintAllEmployeeDetails()
        {
            Console.WriteLine($"Employee ID          :\t {EmpID}");
            Console.WriteLine($"Employee Name        :\t {Name}");
            Console.WriteLine($"Employee Department  :\t {Department}");
            Console.WriteLine($"Employee Designation :\t {Designation}");
            Console.WriteLine($"Employee Basic Salary:\t {BasicSalary}");
            Console.WriteLine("-----------------------------------------------");
        }

        public virtual double EmployeePF(double basicSalary)
        {
            return 0;
        }

        public virtual string LeaveDetails()
        {
            return "";
        }

        public virtual double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }
    }
}
