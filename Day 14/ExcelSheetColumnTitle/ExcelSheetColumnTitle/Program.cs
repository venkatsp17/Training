namespace ExcelSheetColumnTitle
{
    public class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            int columnNumber = 701;
            while(columnNumber > 0)
            {
                columnNumber--;
                char letter = (char)('A' + (columnNumber % 26));
                result += letter;
                columnNumber /= 26;
            }
            Console.WriteLine("The column title is: "+result);
        }
    }
}
