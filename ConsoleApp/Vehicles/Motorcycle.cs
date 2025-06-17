namespace ConsoleApp.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; }
        public Motorcycle(string regNumber, string color, int cylinderVolume)
            : base(regNumber, color, wheels: 2)
        {
            CylinderVolume = cylinderVolume;
        }
    }
}
