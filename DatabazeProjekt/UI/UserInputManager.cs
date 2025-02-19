using Microsoft.IdentityModel.Tokens;

namespace DatabazeProjekt.UI
{
    internal class UserInputManager
    {

        public static string GetStringInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input.");
                return GetStringInput(prompt);
            }

            return input;
        }

        public static string? GetStringInputOptional(string prompt)
        {
            Console.WriteLine("(optional) " + prompt);
            return Console.ReadLine().Trim();
        }


        public static int GetIntInput(string prompt)
        {
            int result;
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine().Trim();
            }
            while (!int.TryParse(input, out result));

            return result;
        }

        public static DateTime GetDateInput(string prompt)
        {
            DateTime result;
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine().Trim();
            }
            while (!DateTime.TryParse(input, out result));

            return result;
        }

        public static DateTime? GetDateInputOptional(string prompt)
        {
            DateTime result;
            string input;
            do
            {
                Console.WriteLine("(optional) " + prompt);
                input = Console.ReadLine().Trim();
                if (input.IsNullOrEmpty()) return null;
            }
            while (!DateTime.TryParse(input, out result));

            return result;
        }

        public static decimal GetDecimalInput(string prompt)
        {
            decimal result;
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine().Trim();
            }
            while (!decimal.TryParse(input, out result) || result < 0);

            return result;
        }

        public static decimal? GetDecimalInputOptional(string prompt)
        {
            decimal result;
            string input;
            do
            {
                Console.WriteLine("(optional) "+prompt);
                input = Console.ReadLine().Trim();
                if (input.IsNullOrEmpty()) return null;
            }
            while (!decimal.TryParse(input, out result) || result < 0);

            return result;
        }

        public static bool? GetBoolInputOptional(string prompt)
        {
            string input;
            while (true)
            {
                Console.WriteLine($"(optional) (yes/no) {prompt}");
                input = Console.ReadLine().Trim().ToLower();

                if (input.IsNullOrEmpty()) return null;
                if (input == "yes" || input == "y")
                    return true;
                if (input == "no" || input == "n")
                    return false;

                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            }
        }
    }
}
