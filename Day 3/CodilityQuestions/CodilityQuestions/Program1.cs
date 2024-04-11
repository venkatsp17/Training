using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityQuestions
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            int[] arr = [1,2,3,4,5,6];
            int d = 3;
            int[] arr1 = new int[arr.Length];
            int j = 0;
            for (int i = d; i < arr.Length; i++)
            {
                arr1[j] = arr[i];
                j++;
            }
            for(int i=0; i<d; i++)
            {
                arr1[j] = arr[i];
                j++;
            }
            Console.WriteLine("The rotated array is:");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i]);
            }

        }
    }
}
