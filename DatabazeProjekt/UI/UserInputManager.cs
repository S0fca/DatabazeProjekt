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

    }
}
