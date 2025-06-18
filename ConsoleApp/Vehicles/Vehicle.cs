namespace ConsoleApp.Vehicles
{
    internal abstract class Vehicle
    {
        public VehicleType Type { get; }
        //TODO: Make sure regNumber is unique across all vehicles.
        public string RegNumber { get; }
        public VehicleColor Color { get; }
        public int Wheels { get; }

        public Vehicle(VehicleType type, string regNumber, VehicleColor color, int wheels)
        {
            Type = type;
            RegNumber = regNumber.ToUpper();
            Color = color;
            Wheels = wheels;
        }
    }
}
