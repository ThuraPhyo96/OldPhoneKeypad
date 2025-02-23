using System.Text;

namespace OldPhoneKeypad.Modules
{
    public class OldPhoneKeyPad
    {
        private const char Backspace = '*';
        private const char Endofinput = '#';
        private const char Delay = ' ';

        // keypad mapping
        private readonly string[] keyPadMappging = [
            " ",
            "&'(",
            "ABC",
            "DEF",
            "GHI",
            "JKL",
            "MNO",
            "PQRS",
            "TUV",
            "WXYZ"
        ];

        public void Process()
        {
            // The program will keep running and asking for input until the user explicitly exits
            while (true)
            {
                Console.WriteLine("Input the number to change letter(end with '#'):");
                string input = Console.ReadLine() ?? string.Empty;

                if (IsValidInput(input))
                {
                    Console.WriteLine(ConvertToText(input));
                }
                else
                {
                    Console.WriteLine("Please input a valid number sequence ending with '#'.");
                }
            }
        }

        private static bool IsValidInput(string input)
        {
            return !string.IsNullOrEmpty(input) && input.EndsWith(Endofinput);
        }

        private static void RemoveLastCharacter(ref StringBuilder result)
        {
            if (result.Length > 0)
            {
                // Remove the last character
                result.Length--;
            }
        }

        public string ConvertToText(string input)
        {
            StringBuilder convertedText = new();
            for (int charIndex = 0; charIndex < input.Length; charIndex++)
            {
                char currentKey = input[charIndex];

                if (currentKey == Endofinput)
                {
                    // Go to the end and stop from loop
                    break;
                }
                else if (currentKey == Backspace)
                {
                    RemoveLastCharacter(ref convertedText);
                    // Go to the next and read the next char
                    continue;
                }
                else if (currentKey == Delay)
                {
                    // Go to the next and read the next char
                    continue;
                }

                // Determine the presses is the same key?
                int sameCharCount = 0;
                for (int nextCharIndex = charIndex; nextCharIndex < input.Length; nextCharIndex++)
                {
                    // if the next char is space or not equal then stop from loop
                    if (input[nextCharIndex] == Delay || input[nextCharIndex] != currentKey)
                        break;

                    // if the current char and the next char is same, then increase same char count
                    if (input[nextCharIndex] == currentKey)
                        sameCharCount++;
                }

                // Check the key is a digit?
                if (char.IsDigit(currentKey))
                {
                    // Convert char to int to take the value from keyPadMappgings
                    int keyPadIndex = currentKey - '0';

                    // keyPadIndex must be between 0 and 9
                    if (keyPadIndex >= 0 && keyPadIndex <= 9)
                    {
                        // Take the letters by keyPadIndex
                        string letters = keyPadMappging[keyPadIndex];

                        if (letters.Length == 0)
                            continue;

                        int letterIndex = (sameCharCount - 1) % letters.Length;
                        convertedText.Append(letters[letterIndex]);
                    }
                }

                // Skip processed char
                charIndex += sameCharCount - 1;
            }

            return convertedText.ToString();
        }
    }

    //public void Run()
    //{
    //    //  The program will keep running and asking for input until the user explicitly exits
    //    //  (E.g., by pressing Ctrl+C or closing the console)
    //    while (true)
    //    {
    //        Console.WriteLine("Input the number to change letter:");
    //        string input = Console.ReadLine() ?? string.Empty;

    //        if (string.IsNullOrEmpty(input))
    //        {
    //            Console.WriteLine("Please input the number!");
    //            continue;
    //        }
    //        else if (!input.EndsWith(hash))
    //        {
    //            Console.WriteLine("Input must end with '#'.");
    //            continue;
    //        }

    //        // Convert input into char array for iteration
    //        char[]? numbers = input?.ToCharArray();
    //        StringBuilder output = new();
    //        int i = 0;

    //        while (i < numbers?.Length)
    //        {
    //            // Take the current char and stored
    //            char currentChar = numbers[i];
    //            if (currentChar == star)
    //            {
    //                if (output.Length > 0)
    //                {
    //                    // Remove the last char from output because the star is backspace
    //                    output.Remove(output.Length - 1, 1);
    //                    i++;
    //                }
    //            }
    //            else if (currentChar == hash)
    //            {
    //                // break out of the loop because the hash is end of input
    //                break;
    //            }
    //            else if (currentChar == space)
    //            {
    //                // increment i by 1 because the space is delay
    //                i++;
    //            }
    //            else
    //            {
    //                // make the key to take the value from Dictionary
    //                // E.g., 2
    //                string sameCharCount = currentChar.ToString();

    //                // Find the same characters
    //                while (i + 1 < input?.Length && currentChar == numbers[i + 1])
    //                {
    //                    // Add the same character to sameCharCount
    //                    // E.g., 22
    //                    sameCharCount += numbers[i + 1].ToString();

    //                    if (sameCharCount.Length >= 4 && ((currentChar >= '2' && currentChar <= '6') || currentChar == '8'))
    //                    {
    //                        sameCharCount = sameCharCount[..^3]; // Cycle within 3 chars
    //                    }
    //                    else if (sameCharCount.Length >= 5 && (currentChar == '7' || currentChar == '9'))
    //                    {
    //                        sameCharCount = sameCharCount[..^4]; // Cycle within 4 chars
    //                    }

    //                    i++;

    //                    // break out of the loop
    //                    if (i == input?.Length)
    //                        break;
    //                }

    //                // Take the value by key and append the mapped char into output
    //                // E.g., mappings["22"], B
    //                if (mappings.TryGetValue(sameCharCount, out string? mappedChar))
    //                {
    //                    output.Append(mappedChar);
    //                }

    //                i++;
    //            }
    //        }

    //        // the output has value, print it
    //        if (output.Length > 0)
    //            Console.WriteLine(output.ToString());

    //        Console.WriteLine();
    //    }
    //}
}
