namespace ConsoleApp.Vehicles
{
    internal class Car : Vehicle
    {
        public int Doors { get; }
        public Car(string regNumber, string color, int wheels, int doors)
            : base(regNumber, color, wheels)
        {
            Doors = doors;
        }
    }
}
