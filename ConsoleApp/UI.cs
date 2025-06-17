namespace ConsoleApp
{
    // This class handles the UI logic for the ConsoleApp project.
    internal class UI
    {
        public void ShowMainMenu()
        {
            Console.WriteLine("Welcome to the Garage Management System!");
            Console.WriteLine("1. View all parked vehicles");
            Console.WriteLine("2. View types of vehicles and how many of each is parked");
            Console.WriteLine("3. Park a vehicle");
            Console.WriteLine("4. Remove a vehicle");
            Console.WriteLine("5. Populate garage with 10 vehicles");
            Console.WriteLine("6. Search for a vehicle based on registration number");
            Console.WriteLine("7. Search for a vehicle based on property");
            Console.WriteLine("0. Exit");
        }

        public string AskForInput(string prompt)
        {
            Console.WriteLine($"{prompt}:");
            return Console.ReadLine() ?? string.Empty;
        }

        public int AskForInt(string prompt)
        {
            int result;
            bool success = false;

            do
            {
                Console.WriteLine($"{prompt}:");
                string input = Console.ReadLine() ?? string.Empty;
                success = int.TryParse(input, out result);

                if (!success)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            } while (!success);

            return result;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
