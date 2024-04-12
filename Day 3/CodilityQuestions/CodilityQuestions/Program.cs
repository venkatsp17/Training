namespace CodilityQuestions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = [];
            Console.WriteLine("Enter the number:");
            int num1 = Convert.ToInt32(Console.ReadLine()); 
            while (num1 > 0)
            {
                arr.Insert(0, num1%2);
                num1 /= 2;
            }
            bool flag= false;
            int count = 0,mc=0;
            foreach (int item in arr)
            {
                if(item == 1)
                {
                    if (flag)
                    {
                       if(count>mc)
                        {
                            mc = count;
                        }
                       count = 0;

                    }
                    flag = true;
                }
                else if (flag)
                {
                    count++;
                }

            }
            Console.WriteLine("Max of intermediate bits:");
            Console.WriteLine(mc);
        }
    }
}
