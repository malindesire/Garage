using ConsoleApp.Vehicles;

namespace ConsoleApp
{
    internal class GarageHandler
    {
        private readonly Garage<Spot> _garage;
        public bool IsFull => _garage.All(spot => spot.IsOccupied);
        public bool IsEmpty => _garage.All(spot => !spot.IsOccupied);
        public GarageHandler(int capacity)
        {
            _garage = new Garage<Spot>(capacity, i => new Spot(i));
        }

        public IEnumerable<Vehicle?> GetParkedVehicles()
        {
            // Implementation for showing all parked vehicles

            return _garage
                    .Where(spot => spot.IsOccupied) // Only occupied spots
                    .Select(spot => spot.ParkedVehicle); // Get the parked vehicles
        }
        public Dictionary<string, int> GetVehicleTypeCount()
        {
            // Implementation for showing vehicle types and counts

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

            return vehicleCounts; // Return a dictionary with vehicle types and their counts
        }
        public bool Park(string regNumber, string color, string vehicleType, int propertyValue )
        {
            // Implementation for parking a vehicle

            Vehicle vehicle = (vehicleType) switch             
            {
                "airplane" => new Airplane(regNumber, color, propertyValue),
                "boat" => new Boat(regNumber, color, propertyValue),
                "bus" => new Bus(regNumber, color, propertyValue),
                "car" => new Car(regNumber, color, propertyValue),
                "motorcycle" => new Motorcycle(regNumber, color, propertyValue),
                _ => throw new ArgumentException("Invalid vehicle type.")
            };

            for (int i = 0; i < _garage.Capacity; i++)
            {
                if (_garage.Spots[i].Park(vehicle))
                {
                    return true; // Vehicle parked successfully
                }
            }

            return false;
        }
        public Vehicle? Remove(string regNumber)
        {
            // Implementation for removing a vehicle

            foreach (var spot in _garage.Spots)
            {
                if (spot.ParkedVehicle != null && spot.ParkedVehicle.RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                {
                    Vehicle vehicle = spot.ParkedVehicle;
                    spot.Vacate();
                    return vehicle;
                }
            }

            return null; // Return null if no vehicle with the given registration number was found
        }
        public void Populate(int count)
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
        }
        public Vehicle? SearchVehicles(string regNumber)
        {
            // Implementation for searching a vehicle by registration number

            return _garage
                    .Where(spot => spot.IsOccupied) // Only occupied spots
                    .Select(spot => spot.ParkedVehicle)
                    .Where(vehicle => vehicle != null && vehicle.RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
        }
        public IEnumerable<Vehicle?> SearchVehicles(string color, int? wheels, string vehicleType)
        {
            // Implementation for searching a vehicle by property

            return _garage
                    .Where(spot => spot.IsOccupied) // Only occupied spots
                    .Select(spot => spot.ParkedVehicle)
                    .Where(vehicle =>
                        (string.IsNullOrEmpty(color) || vehicle != null && vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                        (!wheels.HasValue || vehicle != null && vehicle.Wheels == wheels.Value) &&
                        (string.IsNullOrEmpty(vehicleType) || vehicle != null && vehicle.GetType().Name.Equals(vehicleType, StringComparison.OrdinalIgnoreCase))
                    );

        }
    }
}
