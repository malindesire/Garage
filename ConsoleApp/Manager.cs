using ConsoleApp.Vehicles;

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
                var input = _ui.AskForString("Select an option from the menu");
                if (input == "0")
                {
                    break;
                }
                switch (input)
                {
                    case "1":
                        ShowAllParkedVehicles();
                        break;
                    case "2":
                        ShowVehicleTypesAndCounts();
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

        private bool IsGarageFull()
        {
            if (_garageHandler.IsFull)
            {
                _ui.ShowMessage("The garage is full, cannot park any more vehicles.");
                return true;
            }
            return false;
        }

        private bool IsGarageEmpty()
        {
            if (_garageHandler.IsEmpty)
            {
                _ui.ShowMessage("The garage is empty, no vehicles to show.");
                return true;
            }
            return false;
        }

        private void ShowAllParkedVehicles()
        {
            if (IsGarageEmpty()) return; // Exit if the garage is empty

            _ui.ShowMessage("Vehicles parked in the garage:");

            var vehicles = _garageHandler.GetParkedVehicles();
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    _ui.ShowMessage($"{vehicle.GetType().Name} in {vehicle.Color} with registration number {vehicle.RegNumber}");
                }
            }
        }

        private void ShowVehicleTypesAndCounts()
        {
            if (IsGarageEmpty()) return; // Exit if the garage is empty

            var vehicleCounts = _garageHandler.GetVehicleTypeCount();

            foreach (var kvp in vehicleCounts)
            {
                _ui.ShowMessage($"{kvp.Key}: {kvp.Value} parked");
            }
        }

        private void ParkVehicle()
        {
            if (IsGarageFull()) return; // Exit if the garage is full

            var regNumber = _ui.AskForString("Enter vehicle registration number");
            VehicleColor color = _ui.AskForVehicleColor();
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
            if (IsGarageEmpty()) return; // Exit if the garage is empty

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
            if (IsGarageFull()) return; // Exit if the garage is full

            _garageHandler.Populate(quantity);
            _ui.ShowMessage($"Garage populated with {quantity} vehicles.");

        }

        private void SearchVehicleByRegistrationNumber()
        {
            if (IsGarageEmpty()) return; // Exit if the garage is empty

            _ui.ShowMessage("Search for a vehicle by registration number.");
            string regNumber = _ui.AskForString("Registration Number");
            var vehicle = _garageHandler.SearchVehicle(regNumber);
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
            if (IsGarageEmpty()) return; // Exit if the garage is empty

            _ui.ShowMessage("Search for vehicles by property");
            VehicleColor? color = _ui.AskForOptionalVehicleColor();
            var wheels = _ui.AskForOptionalInt("Wheel Quantity");
            var type = _ui.AskForString("Type of Vehicle");

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
                    if (v == null) continue; // Skip null vehicles
                    _ui.ShowMessage($"{v.GetType().Name} with registration number {v.RegNumber}.");
                }
            }
        }
    }
}
