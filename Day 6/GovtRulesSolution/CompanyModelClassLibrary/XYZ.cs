using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModelClassLibrary
{
    public class XYZ : Employee, GovtRules
    {
        //public XYZ() : base()
        //{

        //}
        public XYZ(int empID, string name, string department, string designation, double basicSalary) : base(empID, name, department, designation, basicSalary)
        {
        }

        public override double EmployeePF(double basicSalary)
        {
            //EMPLOYER_CONTRIBUTION = basicSalary*0.0833;
            return ((basicSalary) * 0.12)*2;
        }

        public override string LeaveDetails()
        {
            return "Leave Details for XYZ: \r\n1. 2 day of Casual Leave per month\r\n2. 5 days of Sick Leave per year\r\n3. 5 days of Previlage Leave per year";
        }

        public override double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }
    }
}
