using ConsoleApp.Vehicles;

namespace ConsoleApp
{
    internal class GarageHandler : IGarageHandler
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
        public bool Park(Vehicle vehicle)
        {
            // Implementation for parking a vehicle

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
        public void Populate(int amount)
        {
            // Implementation for populating the garage with vehicles
            for (int i = 0; i < amount; i++)
            {
                for (int index = 0; index < _garage.Capacity; index++)
                {
                    Vehicle vehicle = VehicleFactory.GenerateRandomVehicle();

                    if (_garage.Spots[index].IsOccupied) continue; // Skip if the spot is already occupied
                    _garage.Spots[index].Park(vehicle); // Attempt to park the generated vehicle

                }
            }

        }
        public Vehicle? SearchVehicle(string regNumber)
        {
            // Implementation for searching a vehicle by registration number

            return _garage
                    .Where(spot => spot.IsOccupied) // Only occupied spots
                    .Select(spot => spot.ParkedVehicle)
                    .Where(vehicle => vehicle != null && vehicle.RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
        }
        public IEnumerable<Vehicle?> SearchVehicles(VehicleColor? color, int? wheels, VehicleType? vehicleType)
        {
            // Implementation for searching a vehicle by property

            return _garage
                    .Where(spot => spot.IsOccupied) // Only occupied spots
                    .Select(spot => spot.ParkedVehicle)
                    .Where(vehicle =>
                        (!color.HasValue || vehicle != null && vehicle.Color.Equals(color)) &&
                        (!wheels.HasValue || vehicle != null && vehicle.Wheels == wheels.Value) &&
                        (!vehicleType.HasValue || vehicle != null && vehicle.Type.Equals(vehicleType))
                    );

        }
    }
}
