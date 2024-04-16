using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModelClassLibrary
{
    public class ABC : Employee, GovtRules
    {
        //public ABC() : base()
        //{

        //}
        public ABC(int empID, string name, string department, string designation, double basicSalary) : base(empID, name, department, designation, basicSalary)
        {

        }

        public override double EmployeePF(double basicSalary)
        {
            //EMPLOYER_CONTRIBUTION = basicSalary*0.0833;
            return (basicSalary)*0.367;
        }

        public override string LeaveDetails()
        {
            return "Leave Details for ABC: \r\n1. 1 day of Casual Leave per month\r\n2. 12 days of Sick Leave per year\r\n3. 10 days of Privilege Leave per year";
        }

        public override double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 5 && serviceCompleted <=10)
            {
                return (basicSalary) * 1;
            }
            else if(serviceCompleted > 10 && serviceCompleted <=20) {
                return (basicSalary) * 2;
            }
            else if(serviceCompleted > 20)
            {
                return (basicSalary) * 3;
            }
            else
            {
                return 0;
            }
        }
    }
}
