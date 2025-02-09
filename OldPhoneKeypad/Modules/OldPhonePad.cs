using System.Text;

namespace OldPhoneKeypad.Modules
{
    public class OldPhonePad
    {
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
            while (true)
            {
                Console.WriteLine("Input the number to change letter:");
                string input = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please input the number!");
                    continue;
                }

                char[]? numbers = input?.ToCharArray();
                StringBuilder output = new();
                int i = 0;

                while (i < numbers?.Length)
                {
                    char currentChar = numbers[i];
                    if (currentChar == star)
                    {
                        if (output.Length > 0)
                        {
                            output.Remove(output.Length - 1, 1);
                            i++;
                        }
                    }
                    else if (currentChar == hash)
                    {
                        break;
                    }
                    else if (currentChar == space)
                    {
                        i++;
                    }
                    else
                    {
                        string sameCharCount = currentChar.ToString();
                        while (i + 1 < input?.Length && currentChar == numbers[i + 1])
                        {
                            sameCharCount += numbers[i + 1].ToString();
                            i++;

                            if (i == input?.Length)
                                break;
                        }

                        if (mappings.TryGetValue(sameCharCount, out string? mappedChar))
                        {
                            output.Append(mappedChar);
                        }

                        i++;
                    }
                }

                if (output.Length > 0)
                    Console.WriteLine(output.ToString());

                Console.WriteLine();
            }
        }
    }
}
