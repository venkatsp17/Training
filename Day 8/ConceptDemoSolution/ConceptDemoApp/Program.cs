using System;

namespace ConceptDemoApp
{

    class SampleCollection<T>
    {
        private T[] arr = new T[100];
        int nextIndex = 0;
        public T this[int i]
        {
            get => arr[i];
        }

        public int this[string i] => Array.IndexOf(arr, i);

        public void Add(T value)
        {
            if (value != null)
            {
                if (typeof(T).Name == "Int32")
                {
                    throw new Exception("Value is a integer");
                }
                if (nextIndex >= arr.Length)
                    throw new IndexOutOfRangeException($"The collection can hold only {arr.Length} elements.");
                arr[nextIndex++] = value;
            }

            
        }
    }


    class Program
    {
        int Divide(int num1, int num2)
        {
            try
            {
                int result = num1 / num2;
                return result;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine("You are trying to divide by zero. Its not worth");
            }
            finally
            {
                Console.WriteLine("Release the divide method resource");
            }
            Console.WriteLine("Your division did not go well");
            return 0;

        }
        public static void Main(String[] args)
        {
            var stringCollection = new SampleCollection<string>();
            stringCollection.Add(1);
            //stringCollection.Add("Hello");
            //stringCollection.Add("World");
            //Console.WriteLine(stringCollection[0]);
            //Console.WriteLine(stringCollection["World"]);

            int num1, num2, result;
            try
            {
                num1 = Convert.ToInt32(Console.ReadLine());
                num2 = Convert.ToInt32(Console.ReadLine());
                result = num1 / num2;
                Console.WriteLine(result);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine("The given data could not be converted to number.");
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine("You are trying to divide by zero. Its not worth");
            }
            Console.WriteLine("Bye bye");

            new Program().Divide(5, 0);
        }
    }
}
