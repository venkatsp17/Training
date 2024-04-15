using ReqTrackerClass;

namespace ReqTrackerApp
{
    internal class Program
    {
        void UnderstandingSequenceStatments()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Hi");
            int num1, num2;
            num1 = 100;
            num2 = 20;
            int num3 = num1 / num2;
            Console.WriteLine($"The result of {num1} divided by {num2} is {num3}");
        }
        void UnderstandingSelectionWithIf()
        {
            string strName = "Ramu";
            if (strName == "Ramu")
            {
                Console.WriteLine("Welcome Ramu. you are authorized");
                Console.WriteLine("Bingo!!");
            }
            else if (strName == "Somu")
                Console.WriteLine("You are Somu not Ramu. ONly Basic access");
            else
                Console.WriteLine("I don't know who you are. Get out...");

        }
        void UnderstandingSwitchCase()
        {
            Console.WriteLine("Please enter a number for day");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("You dont know the numberof days in a week???");
                    break;
            }
        }
        void UnderstandingIterationWithFor()
        {
            for (int i = 0; i < 5; i = i + 2)
            {
                Console.WriteLine("Hello " + i);

            }
        }
        void UnderstandingIterationWithWhile()
        {
            int count = 10;
            while (count > 0)
            {
                count--;
                if (count == 7)
                    continue;
                Console.WriteLine("Thje value of count is " + count);
                if (count == 4)
                    break;

            }
        }
        void UnderstandingIterationWithDoWhile()
        {
            int count = -1;
            do
            {
                Console.WriteLine("In Do while the value is  " + count);
                Console.WriteLine("Please enter the number");
                count = Convert.ToInt32(Console.ReadLine());
            } while (count > 0);
        }

        void UnderstandingArray1()
        {
            int[] arr = {234, 333,22,532,444 };
            int c = 0;
            for(int i = 0;i < arr.Length; i++)
            {
                if (arr[i]/1000==0)
                {
                    if (((arr[i]/10)%10 == arr[i]/100) && arr[i]%10 == (arr[i]/10)%10)
                    {
                        c++;
                    }
                }
            }
            Console.WriteLine("The of repeatind 3 digit numbers present are: "+ c );
        }

        void CreateEmployee() { 
            Employee employee = new Employee();
            employee.BuildEmployeeFromConsole();
            Console.WriteLine("=====================================================");
            employee.PrintEmployeeDetails();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.UnderstandingSequenceStatments();
            //program.UnderstandingSelectionWithIf();
            //program.UnderstandingSwitchCase();
            //program.UnderstandingIterationWithWhile();
            //Console.WriteLine((456/10)%10);
            // program.UnderstandingIterationWithDoWhile();
            program.UnderstandingArray1();
            //program.CreateEmployee();

        }
    }
}
