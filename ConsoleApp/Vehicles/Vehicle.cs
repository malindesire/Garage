namespace ConsoleApp.Vehicles
{
    internal abstract class Vehicle
    {
        public string RegNumber { get; }
        public string Color { get; }
        public int Wheels { get; }

        public Vehicle(string regNumber, string color, int wheels)
        {
            RegNumber = regNumber;
            Color = color;
            Wheels = wheels;
        }
    }
}
