﻿using ModelClassLib;
namespace PracticeSessionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1, employee2;

            employee1 = new Employee(101, "Ramu", new DateTime(2000, 12, 2), "Admin");
            employee2 = new Employee(101, "Ramu", new DateTime(2000, 12, 2), "Admin");
            if (employee1 == employee2)
            {
                Console.WriteLine("Both Same");
            }
            else
            {
                Console.WriteLine($"{employee1} and {employee2} are Not same employee");
            }

        }
    }
}
