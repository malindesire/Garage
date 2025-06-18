using ConsoleApp.Vehicles;

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

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public string AskForString(string prompt)
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

        public int? AskForOptionalInt(string prompt)
        {
            int result;
            bool success = false;

            do
            {
                Console.WriteLine($"{prompt}:");
                string input = Console.ReadLine() ?? string.Empty;

                if (input == string.Empty)
                {
                    return null;
                }

                success = int.TryParse(input, out result);

                if (!success)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            } while (!success);

            return result;
        }

        public VehicleColor AskForVehicleColor()
        {
            var values = Enum.GetValues(typeof(VehicleColor)).Cast<VehicleColor>().ToList();

            Console.WriteLine("Choose a color:");

            for (int i = 0; i < values.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {values[i]}");
            }

            while (true)
            {
                int choice = AskForInt($"Your choice (number)");

                if (choice >= 1 && choice <= values.Count)
                {
                    return values[choice - 1];
                }

                Console.WriteLine("That choice doesn't exist, try again!");
            }
        }
        public VehicleColor? AskForOptionalVehicleColor()
        {
            var values = Enum.GetValues(typeof(VehicleColor)).Cast<VehicleColor>().ToList();

            Console.WriteLine("Choose a color:");

            for (int i = 0; i < values.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {values[i]}");
            }

            while (true)
            {
                int choice = AskForInt($"Your choice (number), choose 0 to skip");

                if (choice == 0) return null;

                if (choice >= 1 && choice <= values.Count)
                {
                    return values[choice - 1];
                }

                Console.WriteLine("That choice doesn't exist, try again!");
            }
        }
    }
}
