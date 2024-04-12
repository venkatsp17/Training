using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Class_Objs.Models
{
    public class Employee
    {
        double salary;
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public Employee(double salary, int id, string name, DateTime dateOfBirth, string email) : this(id)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            Salary = salary;
        }

        public void PrintEmployeeDetails()
        {
            Console.WriteLine($"Employee Id\t:\t{Id}");
            Console.WriteLine($"Employee name\t:\t{Name}");
            Console.WriteLine($"Employee Date Of Birth\t:\t{DateOfBirth}");
            Console.WriteLine($"Employee Salary\t:\tRs.{Salary}");
            Console.WriteLine($"Employee Email\t:\t{Email}");
        }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Email = string.Empty;
            Salary = 0;
        }

        public double Salary
        {
            set
            {
                salary = value - value / 10;
            }
            get
            {
                return salary;
            }
        }
        /// <summary>
        /// Get Employee ID
        /// </summary>
        /// <param name="id">Employee Id as integer</param>
        public Employee(int id) => Id = id;

        internal void Work()
        {
            Console.WriteLine("Working...");
        }

    }
}
