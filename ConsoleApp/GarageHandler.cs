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
        public void ShowAllParkedVehicles()
        {
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
        }
        public void RemoveVehicle()
        {
            // Implementation for removing a vehicle
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
        public void SearchVehicleByRegistrationNumber()
        {
            // Implementation for searching a vehicle by registration number
        }
        public void SearchVehicleByProperty()
        {
            // Implementation for searching a vehicle by property
        }
    }
}
