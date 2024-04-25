using ShoppingDALLibrary;
using ShoppingModelLibrary;
using static ShoppingModelLibrary.Customer;

namespace ShoppingApp
{
    public class Program
    {
        public delegate int calcDel(int n1, int n2);//creating a type that refferes to a method
        void Calculate(calcDel cal)
        {
            int n1 = 10, n2 = 20;
            int result = cal(n1, n2);
            Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        }
        public int Add(int num1, int num2)
        {
            return (num1 + num2);
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Program program = new Program();
            //calcDel c1 = new calcDel(program.Add);
            //program.Calculate(c1);

            Console.WriteLine("OUTPUT 1");
            IRepository<int, Customer> customerRepo = new CustomerRepository();
            customerRepo.Add(new Customer { Id = 1, Name = "A", Age = 23 });
            customerRepo.Add(new Customer { Id = 2, Name = "C", Age = 31 });
            customerRepo.Add(new Customer { Id = 3, Name = "B", Age = 27 });
            var customers = customerRepo.GetAll().ToList();
            customers = customers.OrderBy(cust => cust.Name).ToList();
            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("OUTPUT 2");
            var customers1 = customerRepo.GetAll().ToList();
            customers1.Sort(new SortCustomerByName());
            foreach (var item in customers1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("OUTPUT 3");
            var customers2 = customerRepo.GetAll().ToList();
            customers2.OrderByDescending(cust=>cust.Name).ThenByDescending(cust=>cust.Age).ToList();
            foreach (var item in customers1)
            {
                Console.WriteLine(item);
            }

        }
    }
}
