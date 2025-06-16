namespace ConsoleApp.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; }
        public Motorcycle(string regNumber, string color, int wheels, int cylinderVolume)
            : base(regNumber, color, wheels)
        {
            CylinderVolume = cylinderVolume;
        }
    }
}
