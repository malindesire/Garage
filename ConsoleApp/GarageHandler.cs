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
                else
                {
                    _ui.ShowMessage($"Spot {spot.Number}: Empty");
                }
            }
        }
        public void ShowVehicleTypesAndCounts()
        {
            // Implementation for showing vehicle types and counts
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
