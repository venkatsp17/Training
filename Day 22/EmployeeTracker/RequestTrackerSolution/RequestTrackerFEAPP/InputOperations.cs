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
            while(int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid Input. Try Again!");
            }
            return input;
        }
    }
}
