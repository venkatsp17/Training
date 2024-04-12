namespace ValidateIds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long id;
            while (!(long.TryParse(Console.ReadLine(), out id)))
            {
                Console.WriteLine("Invalid Entry! Try Again..");
            }
            int c = 1;
            long rev=0;
            while(id > 0)
            {
                int digit = (int)(id % 10);
                if(c%2==0)
                {
                    digit *= 2;
                    if((digit.ToString()).Length == 2)
                    {
                        digit = digit / 10 + digit % 10;
                    }
                }
                rev += digit;
                id /= 10;
                c++;
            }
            if (rev % 10 == 0)
            {
                Console.WriteLine("Valid ID");
            }
            //Console.WriteLine(rev);
        }
    }
}
