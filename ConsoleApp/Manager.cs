

namespace ConsoleApp
{
    internal class Manager
    {
        private readonly UI _ui;
        private readonly GarageHandler _garageHandler = new GarageHandler(15); // Assuming a garage with 15 spots

        public Manager()
        {
            _ui = new UI();
        }

        public void Run() 
        {
            _ui.ShowMainMenu();

            while (true)
            {
                var input = _ui.AskForString("Select an option");
                if (input == "0")
                {
                    break;
                }
                switch (input)
                {
                    case "1":
                        _garageHandler.ShowAllParkedVehicles();
                        break;
                    case "2":
                        _garageHandler.ShowVehicleTypesAndCounts();
                        break;
                    case "3":
                        _garageHandler.ParkVehicle();
                        break;
                    case "4":
                        _garageHandler.RemoveVehicle();
                        break;
                    case "5":
                        _garageHandler.PopulateGarageWithVehicles(10);
                        break;
                    case "6":
                        _garageHandler.SearchVehicleByRegistrationNumber();
                        break;
                    case "7":
                        SearchVehicleByProperty();
                        break;
                    default:
                        _ui.ShowMessage("Invalid option, please try again.");
                        break;
                }
            }
        }

        private void SearchVehicleByProperty()
        {
            _ui.ShowMessage("Search for vehicles by property, press enter if you want to skip a property.");
            string color = _ui.AskForString("Color");
            int wheels = _ui.AskForInt("Wheel Quantity");
            string type = _ui.AskForString("Type of Vehicle");

            var results = _garageHandler.SearchVehicles(color, wheels, type);

            if (!results.Any())
            {
                _ui.ShowMessage("No vehicles matched the criteria.");
            }
            else
            {
                _ui.ShowMessage($"Found {results.Count()} vehicles matching the criteria:");
                foreach (var v in results)
                {
                    _ui.ShowMessage($"{v.GetType().Name} with registration number {v.RegNumber}.");
                }
            }
        }
    }
}
