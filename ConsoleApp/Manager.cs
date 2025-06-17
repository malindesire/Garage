





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
                        ParkVehicle();
                        break;
                    case "4":
                        RemoveVehicle();
                        break;
                    case "5":
                        PopulateGarageWithVehicles(10);
                        break;
                    case "6":
                        SearchVehicleByRegistrationNumber();
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

        private void ParkVehicle()
        {
            var regNumber = _ui.AskForString("Enter vehicle registration number");
            var color = _ui.AskForString("Enter vehicle color");
            var vehicleType = _ui.AskForString("Enter vehicle type (Airplane, Boat, Bus, Car, Motorcycle)").ToLower();
            int propertyValue = 0;

            switch (vehicleType)             
            {
                case "airplane":
                    propertyValue = _ui.AskForInt("Enter airplane wingspan");
                    break;
                case "boat":
                    propertyValue = _ui.AskForInt("Enter boat length");
                    break;
                case "bus":
                    propertyValue = _ui.AskForInt("Enter number of seats");
                    break;
                case "car":
                    propertyValue = _ui.AskForInt("Enter number of doors");
                    break;
                case "motorcycle":
                    propertyValue = _ui.AskForInt("Enter cylinder volume");
                    break;
                default:
                    _ui.ShowMessage("Invalid vehicle type entered.");
                    return; // Exit if the vehicle type is invalid
            }

            bool parked = _garageHandler.Park(regNumber, color, vehicleType, propertyValue);
            if (parked)
            {
                _ui.ShowMessage($"Vehicle of type {vehicleType} with registration number {regNumber} parked successfully.");
            }
            else
            {
                _ui.ShowMessage("Garage is full, could not park the vehicle.");
            }
        }

        private void RemoveVehicle()
        {
            var regNumber = _ui.AskForString("Enter vehicle registration number to remove");
            var vehicle = _garageHandler.Remove(regNumber);
            if (vehicle == null)
            {
                _ui.ShowMessage("No vehicle found with that registration number.");
            }
            else
            {
                _ui.ShowMessage($"{vehicle.GetType().Name} with registration number {vehicle.RegNumber} removed from garage.");
            }

        }

        private void PopulateGarageWithVehicles(int quantity)
        {
            _garageHandler.Populate(quantity);
            _ui.ShowMessage($"Garage populated with {quantity} vehicles.");

        }

        private void SearchVehicleByRegistrationNumber()
        {
            _ui.ShowMessage("Search for a vehicle by registration number.");
            string regNumber = _ui.AskForString("Registration Number");
            var vehicle = _garageHandler.SearchVehicles(regNumber);
            if (vehicle == null)
            {
                _ui.ShowMessage("No vehicle found with that registration number.");
            }
            else
            {
                _ui.ShowMessage($"Found vehicle: {vehicle.GetType().Name} with registration number {vehicle.RegNumber}.");
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
