using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityQuestions
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            int[] arr = { 9, 3, 9, 3, 9, 7, 9 };
            int bitxor=0;
            for(int i = 0; i < arr.Length; i++)
            {
                bitxor ^= arr[i];
            }
            Console.WriteLine("Missing Pair element:");
            Console.WriteLine(bitxor);
        }
    }
}
