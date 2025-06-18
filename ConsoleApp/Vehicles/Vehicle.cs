namespace ConsoleApp.Vehicles
{
    internal abstract class Vehicle
    {
        private static HashSet<string> _usedRegNumbers = new HashSet<string>();
        public VehicleType Type { get; }
        public string RegNumber { get; }
        public VehicleColor Color { get; }
        public int Wheels { get; }

        public Vehicle(VehicleType type, string regNumber, VehicleColor color, int wheels)
        {
            //TODO: Handle exceptions for invalid inputs
            if (_usedRegNumbers.Contains(regNumber))
            {
                throw new ArgumentException($"Registration number '{regNumber}' is already in use.");
            }

            Type = type;
            RegNumber = regNumber.ToUpper();
            Color = color;
            Wheels = wheels;
            _usedRegNumbers.Add(regNumber.ToUpper());

        }
    }
}
