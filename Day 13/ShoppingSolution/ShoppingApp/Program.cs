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

        int GetResultFromDatabaseServer()
        {
            return new Random().Next();
        }

        void PrintNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("By " + Thread.CurrentThread.Name + " " + i);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            //console.writeline("hello, world!");
            //program program = new program();
            //calcdel c1 = new calcdel(program.add);
            //program.calculate(c1);

            //console.writeline("output 1");
            //irepository<int, customer> customerrepo = new customerrepository();
            //customerrepo.add(new customer { id = 1, name = "a", age = 23 });
            //customerrepo.add(new customer { id = 2, name = "c", age = 31 });
            //customerrepo.add(new customer { id = 3, name = "b", age = 27 });
            //var customers = customerrepo.getall().tolist();
            //customers = customers.orderby(cust => cust.name).tolist();
            //foreach (var item in customers)
            //{
            //    console.writeline(item);
            //}
            //console.writeline("output 2");
            //var customers1 = customerrepo.getall().tolist();
            //customers1.sort(new sortcustomerbyname());
            //foreach (var item in customers1)
            //{
            //    console.writeline(item);
            //}
            //console.writeline("output 3");
            //var customers2 = customerrepo.getall().tolist();
            //customers2.orderbydescending(cust => cust.name).thenbydescending(cust => cust.age).tolist();
            //foreach (var item in customers1)
            //{
            //    console.writeline(item);
            //}

            //Console.WriteLine("Hello, World!");
            //Program program = new Program();
            //int number = program.GetResultFromDatabaseServer();
            //Console.WriteLine("This is the random number from main" + new Random().Next());
            //Console.WriteLine("This is the random number from server " + number);

            Program program = new Program();
            Thread t1 = new Thread(program.PrintNumbers);
            t1.Name = "You";
            Thread t2 = new Thread(program.PrintNumbers);
            t2.Name = "Me";
            t1.Start();
            t2.Start();
            Console.WriteLine("After the thread call");

        }
    }
}
