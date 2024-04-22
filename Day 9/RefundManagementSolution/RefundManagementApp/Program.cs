namespace RefundManagementApp
{
    public class Program
    {
        int GetIntInput()
        {
            int inp;
            while(int.TryParse(Console.ReadLine(), out inp))
            {
                Console.WriteLine("Invalid Input. Try Again!");
            }
            return inp;
        }
        void Menu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Get All Employees");
            Console.WriteLine("3. Get Employee By ID");

        }
        void RefundManagement()
        {
            int choice;
            while (true)
            {
                choice = GetIntInput();
                switch(choice)
                {
                    case 0: 
                }
            }
        }
        static void Main(string[] args)
        {
            RefundManagement();
        }
    }
}
