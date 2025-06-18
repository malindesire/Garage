namespace ConsoleApp.Vehicles
{
    internal class Car : Vehicle
    {
        public int Doors { get; }
        public Car(string regNumber, string color, int doors)
            : base(VehicleType.Car, regNumber, color, wheels: 4)
        {
            Doors = doors;
        }
    }
}
