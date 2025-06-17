namespace ConsoleApp.Vehicles
{
    internal abstract class Vehicle
    {
        //TODO: Make sure regNumber is unique across all vehicles.
        public string RegNumber { get; }
        public string Color { get; }
        public int Wheels { get; }

        public Vehicle(string regNumber, string color, int wheels)
        {
            RegNumber = regNumber.ToUpper();
            Color = color;
            Wheels = wheels;
        }
    }
}
