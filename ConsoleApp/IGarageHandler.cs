using ConsoleApp.Vehicles;

namespace ConsoleApp
{
    internal interface IGarageHandler
    {
        bool IsEmpty { get; }
        bool IsFull { get; }

        IEnumerable<Vehicle?> GetParkedVehicles();
        Dictionary<string, int> GetVehicleTypeCount();
        bool Park(Vehicle vehicle);
        void Populate(int amount);
        Vehicle? Remove(string regNumber);
        Vehicle? SearchVehicle(string regNumber);
        IEnumerable<Vehicle?> SearchVehicles(VehicleColor? color, int? wheels, VehicleType? vehicleType);
    }
}