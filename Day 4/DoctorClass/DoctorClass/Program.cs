using DoctorClass.Models;

namespace DoctorClass
{
    public class Program
    {
        Doctor CreateDoctorDetails(int id)
        {
            Console.WriteLine($"Doctor {id-100} Detail\n");
            Doctor doc = new Doctor(id);
            Console.WriteLine("Enter Doctor Name:");
            doc.Name = Console.ReadLine();
            int age;
            Console.WriteLine("Enter Doctor Age:");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            int exp;
            Console.WriteLine("Enter Doctor Experience:");
            while (!int.TryParse(Console.ReadLine(), out exp))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            doc.Age = age;
            doc.Experience = exp;
            Console.WriteLine("Enter Doctor Qualification:");
            doc.Qualification = Console.ReadLine();
            Console.WriteLine("Enter Doctor Specialization:");
            doc.Specialization = Console.ReadLine();

            return doc;
        }
        static void Main(string[] args)
        {
            Program pro = new Program();
            Doctor[] docs = new Doctor[3];
            for (int i = 0; i < docs.Length; i++)
            {
                docs[i] = pro.CreateDoctorDetails(101 + i);
                Console.WriteLine("\n\n\n");
            }
            Console.WriteLine("\n\n\nDoctor Details:");
            for (int i = 0; i < docs.Length; i++)
            {
                docs[i].PrintDetails();
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\n\n\nFind Doctor by Specialization");
            Console.WriteLine("Enter the Specialization to proceed further:");
            string spcl = Console.ReadLine();
            for (int i = 0;i < docs.Length;i++)
            {
                if (docs[i].Specialization == spcl)
                {
                    docs[i].PrintDetails();
                    break;
                }
            }
        }
    }
}
