using System.Net.Sockets;

namespace ValidateIds
{
    class Program
    {
        /// <summary>
        /// Get Digit sum if it is two digit number or return number by multiplting it by 2
        /// </summary>
        /// <param name="digit">Digit as (int)</param>
        /// <returns></returns>
        static int GetDigitSum(int digit)
        {
            digit *= 2;
            return digit < 10 ? digit : digit / 10 + digit % 10;
        }

        /// <summary>
        /// Function that validates Id and return bool
        /// </summary>
        /// <param name="id">Get id as (long)</param>
        /// <returns></returns>
        static bool ValidateID(long id)
        {
            int c = 1;
            long rev = 0;
            while (id > 0)
            {
                int digit = (int)(id % 10);
                if (c % 2 == 0)
                {
                    digit = GetDigitSum(digit);
                }
                rev += digit;
                id /= 10;
                c++;
            }
            if (rev % 10 == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Function to get Long Input
        /// </summary>
        /// <returns></returns>
         static long GetLongInp()
        {
            Console.WriteLine("Enter a number:");
            long id;
            while (!(long.TryParse(Console.ReadLine(), out id)))
            {
                Console.WriteLine("Invalid Entry! Try Again..");
            }
            return id;
        }

        static void Main(string[] args)
        {
            long id = GetLongInp();   
            if(ValidateID(id))
            {
                Console.WriteLine($"{id} is Valid!");
            }
            else
            {
                Console.WriteLine($"{id} not is Valid!");
            }
        }
    }
}
