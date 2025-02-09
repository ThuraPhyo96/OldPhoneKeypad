using System.Text;

namespace OldPhoneKeypad.Modules
{
    public class OldPhonePad
    {
        // Initialize the Dictionary to store key value pairs and take the value by key
        // Initialize the 3 const: Star(Backspace), Hash(End of input) and Space(Delay)
        private readonly Dictionary<string, string> mappings = new()
            {
                { "0", " "},
                { "1", "&"},
                { "11", "'"},
                { "111", "("},
                { "2", "A"},
                { "22", "B"},
                { "222", "C"},
                { "3", "D"},
                { "33", "E"},
                { "333", "F"},
                { "4", "G"},
                { "44", "H"},
                { "444", "I"},
                { "5", "J"},
                { "55", "K"},
                { "555", "L"},
                { "6", "M"},
                { "66", "N"},
                { "666", "O"},
                { "7", "P"},
                { "77", "Q"},
                { "777", "R"},
                { "7777", "S"},
                { "8", "T"},
                { "88", "U"},
                { "888", "V"},
                { "9", "W"},
                { "99", "X"},
                { "999", "Y"},
                { "9999", "Z"}
            };
        private const char star = '*';
        private const char hash = '#';
        private const char space = ' ';

        public void Run()
        {
            //  The program will keep running and asking for input until the user explicitly exits
            //  (E.g., by pressing Ctrl+C or closing the console)
            while (true)
            {
                Console.WriteLine("Input the number to change letter:");
                string input = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please input the number!");
                    continue;
                }
                else if (!input.EndsWith(hash))
                {
                    Console.WriteLine("Input must end with '#'.");
                    continue;
                }

                // Convert input into char array for iteration
                char[]? numbers = input?.ToCharArray();
                StringBuilder output = new();
                int i = 0;

                while (i < numbers?.Length)
                {
                    // Take the current char and stored
                    char currentChar = numbers[i];
                    if (currentChar == star)
                    {
                        if (output.Length > 0)
                        {
                            // Remove the last char from output because the star is backspace
                            output.Remove(output.Length - 1, 1);
                            i++;
                        }
                    }
                    else if (currentChar == hash)
                    {
                        // break out of the loop because the hash is end of input
                        break;
                    }
                    else if (currentChar == space)
                    {
                        // increment i by 1 because the space is delay
                        i++;
                    }
                    else
                    {
                        // make the key to take the value from Dictionary
                        // E.g., 2
                        string sameCharCount = currentChar.ToString();

                        // Find the same characters
                        while (i + 1 < input?.Length && currentChar == numbers[i + 1])
                        {
                            // Add the same character to sameCharCount
                            // E.g., 22
                            sameCharCount += numbers[i + 1].ToString();

                            if (sameCharCount.Length >= 4 && ((currentChar >= '2' && currentChar <= '6') || currentChar == '8'))
                            {
                                sameCharCount = sameCharCount[..^3]; // Cycle within 3 chars
                            }
                            else if (sameCharCount.Length >= 5 && (currentChar == '7' || currentChar == '9'))
                            {
                                sameCharCount = sameCharCount[..^4]; // Cycle within 4 chars
                            }

                            i++;

                            // break out of the loop
                            if (i == input?.Length)
                                break;
                        }

                        // Take the value by key and append the mapped char into output
                        // E.g., mappings["22"], B
                        if (mappings.TryGetValue(sameCharCount, out string? mappedChar))
                        {
                            output.Append(mappedChar);
                        }

                        i++;
                    }
                }

                // the output has value, print it
                if (output.Length > 0)
                    Console.WriteLine(output.ToString());

                Console.WriteLine();
            }
        }
    }
}
