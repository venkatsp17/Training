using System.Data;
using System.Globalization;

namespace RefundManagementModelLibrary
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        string dept;
        public string Department {
            get
            {
                return dept;
            } 
            set {
                dept = value;
                if(dept == "HR")
                    ExpenseAcess = true;
            } 
        }
        bool ExpenseAcess { get; set; } = false;

        public Employee()
        {
            EmployeeId = 0;
            Name = string.Empty;
            Department = string.Empty;
            ExpenseAcess = false;
        }

        public Employee(int employeeId, string name, string department)
        {
            EmployeeId = employeeId;
            Name = name;
            Department = department;
        }

        public override string ToString()
        {
            return "\nEmployee Id  : " + EmployeeId
                + "\nEmployee Name :" + Name
                + "\nDepartment    : " + Department;
        }
    }
}
