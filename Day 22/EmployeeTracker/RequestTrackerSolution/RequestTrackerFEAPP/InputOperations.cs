using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class InputOperations
    {
        public int GetIntInput()
        {
            int input;
            while(!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid Input. Try Again!");
            }
            return input;
        }

        public double GetDoubleInput()
        {
            double input;
            while (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid Input. Try Again!");
            }
            return input;
        }

        public float GetFloatInput()
        {
            float input;
            while (!float.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid Input. Try Again!");
            }
            return input;
        }

        public string GetStringInput()
        {
            string input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid Input. Try Again!");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
    }
}
