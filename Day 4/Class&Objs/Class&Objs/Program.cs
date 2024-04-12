using Class_Objs.Models;

namespace Class_Objs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Id = 1;
            emp.Salary = 10000;
            emp.Name = "Venkat S P";
            Employee emp2 = new Employee(2);
            Console.WriteLine($"Id: {emp.Id}\nName: {emp.Name}\nSalary:{emp.Salary} ");
            Employee employee2 = new Employee
            {
                Name = "Somu",
                DateOfBirth = new DateTime(2000, 3, 6),
                Email = "somu@abccorp.com",
                Salary = 40000
            };
            employee2.PrintEmployeeDetails();
            emp.Work();
        }
    }
}
