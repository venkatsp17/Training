using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    internal static class Program
    {
        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        static int Sub(int num1, int num2)
        {
            return num1 - num2;
        }
        static int Product(int num1, int num2)
        {
            return num1 * num2;
        }
        static int Remainder(int num1, int num2)
        {
            return num1 % num2;
        }
        static bool Divide(int num1, int num2, out string msg, out double res, out int rem)
        {
            msg = "";
            res = 0;
            rem = 0;
            if(num2 == 0)
            {
                msg = "Cannot divide by 0";
                return false;
            }
            res = (double)num1 / (double)num2;
            rem = Remainder(num1, num2);
            return true;
        }
        static int TakeNumber()
        {
            int num1;
            Console.WriteLine("Enter number:");
            while (!int.TryParse(Console.ReadLine(), out num1))
                Console.WriteLine("Invalid entry. Enter valid number");
            return num1;
        }

        static string TakeString()
        {
            string inp;
            Console.WriteLine("Enter the string:");
            inp = Console.ReadLine()??"";
            return inp;
        }
        static void Calculate()
        {
            int num1, num2;
            num1 = TakeNumber();
            num2 = TakeNumber();
            PrintResult(Convert.ToString(Add(num1, num2)), "Sum");
            PrintResult(Convert.ToString(Sub(num1, num2)), "SubTraction");
            PrintResult(Convert.ToString(Product(num1, num2)), "Product");
            bool val = Divide(num1, num2, out string msg, out double result, out int reminder);
            if(val){
                PrintResult(Convert.ToString(result), "Division");
                PrintResult(Convert.ToString(reminder), "Reminder");
            }
            else
            {
                Console.WriteLine(msg);
            }
           
        }

        static void PrintResult(string sum, string ops)
        {
            Console.WriteLine($"The {ops} is {sum}");
        }

        static void FindGreatest()
        {
            int num1;
            int maximum = int.MinValue;
            while (true)
            {
                num1 = TakeNumber();
                if (num1 < 0)
                {
                    break;
                }
                if (num1 > maximum)
                {
                    maximum = num1;
                }
            }
            PrintResult(Convert.ToString(maximum), "Maximum");
        }

        static void FindAvgBy7()
        {
            int num1;
            int c = 0, sum1=0;
            while (true)
            {
                num1 = TakeNumber();
                if (num1 < 0)
                {
                    break;
                }
                if (Remainder(num1, 7) == 0 && num1 !=0)
                {
                    sum1 += num1;
                    c++;
                }    
            }
            PrintResult(Convert.ToString((double)(sum1/c)), "Average");
        }

        static void StringLength()
        {
            string Name = TakeString();
            PrintResult(Convert.ToString(Name.Length), "user name length");
        }

        static void UserLogin()
        {
            int counts = 0;
            while(true)
            {
                if (counts > 2)
                {
                    Console.WriteLine("The number of attempts exceeded.");
                    break;
                }
                string username = TakeString();
                string password = TakeString();
                if(username=="ABC" && password == "123")
                {
                    Console.WriteLine("Login Successfull!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Username or Password");
                    counts++;
                    Console.WriteLine($"Attempt {counts}\n");
                }
            }

        }


        static int CountRepeatingVowels(string word)
        {
            word = word.ToLower();
            char[] vowels = ['a', 'e', 'i', 'o', 'u'];

            int count = 0;
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (vowels.Contains(word[i]) && vowels.Contains(word[i + 1]))
                {
                    count++;
                    i++;
                }
            }

            return count;
        }

        static void VowelWord()
        {
           string line = TakeString();
           string[] words = line.Split(',');
           int minVowelCount = int.MaxValue;
           string[] minVowelWords = [];

            foreach (string word in words)
            {
                int vowelCount = CountRepeatingVowels(word);
                if (vowelCount < minVowelCount)
                {
                    minVowelCount = vowelCount;
                    minVowelWords = [word];
                }
                else if (vowelCount == minVowelCount)
                {
                    minVowelWords = minVowelWords.Append(word).ToArray();
                }
            }

            Console.WriteLine($"Words with the least number of repeating vowels ({minVowelCount}):");
            foreach (string word in minVowelWords)
            {
                Console.WriteLine(word);
            }

        }
        static void Main(string[] args)
        {
            //sum, sub, product, division, remainder
            //Console.WriteLine("Calculate Add, Sub, Product, Divison, Remainder");
            //Calculate(); 



            // Finding Greatest number
            //Console.WriteLine("Find Greatest of All");
            //FindGreatest(); 



            //Find Avg of numbers Divisible by 7
            //Console.WriteLine("Find Avg of numbers Divisible by 7");
            //FindAvgBy7();


            //Length of Name
            //Console.WriteLine("Find Length of Name");
            //StringLength();

            //User Login
            //Console.WriteLine("User Login");
            //UserLogin();

            //Find minimum Vowel words.
            Console.WriteLine("Find minimum vowel word");
            VowelWord();

        }
    }
}
