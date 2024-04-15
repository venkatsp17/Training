namespace CowBullProblem
{
    internal class Program
    {
        string GetStringInput()
        {
            string inp;
            do
            {
                Console.WriteLine("Enter word:");
                inp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inp) || inp.Length > 4)
                {
                    Console.WriteLine("Invalid Input! Try again..");
                }
            } while (string.IsNullOrWhiteSpace(inp));
            return inp;
        }

        void CountBullsCows(string secret, string guess, out int cows, out int bulls) {
            int c=0, b=0;
            int[] freq = new int[26];
            for (int i = 0; i < secret.Length; i++) {
                if (secret[i] == guess[i]) {
                    c++;
                }
                else
                {
                    freq[secret[i]-'a']++;
                }    
            }
            for (int i = 0; i < guess.Length; i++)
            {
                if (secret[i]!= guess[i] && freq[guess[i] - 'a'] > 0) {
                    b++;
                    freq[guess[i]-'a']--;
                }
            }
            cows = c;
            bulls = b;    
        }

        void PrintWords(string[] words)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Words so far:");
            for (int i = words.Length-1; i >= 0; i--)
            {
                if (string.IsNullOrEmpty(words[i])){
                    break;
                }
                Console.WriteLine(words[i]);
               
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-----------------------------");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            string word = "golf";
            string input;
            int cows,bulls;
            int attempts = 10;
            string[] words = new string[10];
            do
            {
                input = program.GetStringInput();
                program.CountBullsCows(word, input, out cows, out bulls);
                Console.WriteLine($"Cows: {cows}\tBulls: {bulls}");
                Console.WriteLine("-----------------------------");
                if (cows == input.Length)
                {
                    Console.WriteLine("Bingo!!! You found the word");
                    break;
                }
                else
                {
                    attempts--;
                    words[attempts] = input;
                    program.PrintWords(words);
                    Console.WriteLine($"You have {attempts} left!");
                }
                
            } while (attempts>0);
        }
    }
}
