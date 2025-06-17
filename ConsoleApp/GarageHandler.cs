using ConsoleApp.Vehicles;

namespace ConsoleApp
{
    internal class GarageHandler
    {
        private readonly Garage<Spot> _garage;
        private readonly UI _ui;
        public GarageHandler(int capacity)
        {
            _garage = new Garage<Spot>(capacity, i => new Spot(i));
            _ui = new UI();
        }

        public bool CheckFullGarage()
        {
            if (_garage.IsFull)
            {
                _ui.ShowMessage("The garage is full.");
                return true;
            }

            return false; // Garage is not full
        }
        public bool CheckEmptyGarage()
        {
            if (_garage.IsEmpty)
            {
                _ui.ShowMessage("The garage is empty.");
                return true;
            }

            return false; // Garage is not empty
        }
        public void ShowAllParkedVehicles()
        {
            // Implementation for showing all parked vehicles
            if (CheckEmptyGarage()) return;

            foreach (var spot in _garage.Spots)
            {
                if (spot.ParkedVehicle != null)
                {
                    _ui.ShowMessage($"Spot {spot.Number}: {spot.ParkedVehicle.GetType().Name} - {spot.ParkedVehicle.RegNumber}");
                }
            }
        }
        public void ShowVehicleTypesAndCounts()
        {
            // Implementation for showing vehicle types and counts
            if (CheckEmptyGarage()) return;

            var vehicleCounts = new Dictionary<string, int>(); 
            foreach (var spot in _garage.Spots)
            {
                if (spot.ParkedVehicle != null)
                {
                    var vehicleType = spot.ParkedVehicle.GetType().Name;
                    if (vehicleCounts.ContainsKey(vehicleType))
                    {
                        vehicleCounts[vehicleType]++;
                    }
                    else
                    {
                        vehicleCounts[vehicleType] = 1;
                    }
                }
            }

            foreach (var kvp in vehicleCounts)
            {
                _ui.ShowMessage($"{kvp.Key}: {kvp.Value} parked");
            }
        }
        public void ParkVehicle()
        {
            // Implementation for parking a vehicle
            if (CheckFullGarage()) return;

            var regNumber = _ui.AskForString("Enter vehicle registration number");
            var color = _ui.AskForString("Enter vehicle color");
            var vehicleType = _ui.AskForString("Enter vehicle type (Airplane, Boat, Bus, Car, Motorcycle)").ToLower();
            Vehicle vehicle;

            if (vehicleType == "airplane")
            {
                int wingspan = _ui.AskForInt("Enter airplane wingspan");
                vehicle = new Airplane(regNumber, color, wingspan);
            } else if (vehicleType == "boat")
            {
                int length = _ui.AskForInt("Enter boat length");
                vehicle = new Boat(regNumber, color, length);
            } else if (vehicleType == "bus")
            {
                int capacity = _ui.AskForInt("Enter bus capacity");
                vehicle = new Bus(regNumber, color, capacity);
            } else if (vehicleType == "car")
            {
                int doors = _ui.AskForInt("Enter number of doors");
                vehicle = new Car(regNumber, color, doors);
            } else if (vehicleType == "motorcycle")
            {
                int cylinderVolume = _ui.AskForInt("Enter cylinder volume");
                vehicle = new Motorcycle(regNumber, color, cylinderVolume);
            } else
            {
                _ui.ShowMessage("Invalid vehicle type entered.");
                return; // Exit if the vehicle type is invalid
            }
            ;

            for (int i = 0; i < _garage.Capacity; i++)
            {
                if (_garage.Spots[i].Park(vehicle))
                {
                    _ui.ShowMessage($"Vehicle parked in spot {i + 1}.");
                    break;
                }
            }
        }
        public void RemoveVehicle()
        {
            // Implementation for removing a vehicle
            if (CheckEmptyGarage()) return;

            var regNumber = _ui.AskForString("Enter vehicle registration number to remove");
            bool found = false;
            foreach (var spot in _garage.Spots)
            {
                if (spot.ParkedVehicle != null && spot.ParkedVehicle.RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                {
                    Vehicle vehicle = spot.ParkedVehicle;
                    spot.Vacate();
                    _ui.ShowMessage($"{vehicle.GetType().Name} with registration number {vehicle.RegNumber} has been removed from spot {spot.Number}.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                _ui.ShowMessage($"No vehicle found with registration number {regNumber}.");
            }
        }
        public void PopulateGarageWithVehicles(int count)
        {
            // Implementation for populating the garage with vehicles
            var airplane = new Airplane("ABC123", "white", 60);
            var boat = new Boat("DEF123", "black", 55);
            var bus = new Bus("GHI123", "green", 35);
            var car = new Car("JKL123", "red", 2);
            var motorcycle = new Motorcycle("MNO123", "yellow", 125);

            _garage.Spots[0].Park(airplane);
            _garage.Spots[7].Park(airplane);
            _garage.Spots[8].Park(airplane);
            _garage.Spots[1].Park(boat);
            _garage.Spots[2].Park(bus);
            _garage.Spots[3].Park(car);
            _garage.Spots[9].Park(car);
            _garage.Spots[4].Park(motorcycle);
            _garage.Spots[5].Park(motorcycle);
            _garage.Spots[6].Park(motorcycle);

            _ui.ShowMessage($"Garage populated with {count} vehicles.");
        }
        public Vehicle? SearchVehicles(string regNumber)
        {
            // Implementation for searching a vehicle by registration number

            return _garage
                    .Where(spot => spot.IsOccupied) // Bara upptagna platser
                    .Select(spot => spot.ParkedVehicle)
                    .Where(vehicle => vehicle != null && vehicle.RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
        }
        public IEnumerable<Vehicle?> SearchVehicles(string color, int? wheels, string vehicleType)
        {
            // Implementation for searching a vehicle by property

            return _garage
                    .Where(spot => spot.IsOccupied) // Bara upptagna platser
                    .Select(spot => spot.ParkedVehicle)
                    .Where(vehicle =>
                        (string.IsNullOrEmpty(color) || vehicle != null && vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                        (!wheels.HasValue || vehicle != null && vehicle.Wheels == wheels.Value) &&
                        (string.IsNullOrEmpty(vehicleType) || vehicle != null && vehicle.GetType().Name.Equals(vehicleType, StringComparison.OrdinalIgnoreCase))
                    );

        }
    }
}
