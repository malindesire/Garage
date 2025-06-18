namespace ConsoleApp.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; }
        public Motorcycle(string regNumber, VehicleColor color, int cylinderVolume)
            : base(VehicleType.Motorcycle, regNumber, color, wheels: 2)
        {
            CylinderVolume = cylinderVolume;
        }
    }
}
