namespace ConsoleApp.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int Wingspan { get; }
        public Airplane(string regNumber, string color, int wingspan)
            : base(VehicleType.Airplane, regNumber, color, wheels: 6)
        {
            Wingspan = wingspan;
        }
    }
}
