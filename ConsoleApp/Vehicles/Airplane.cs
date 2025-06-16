namespace ConsoleApp.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int Wingspan { get; }
        public Airplane(string regNumber, string color, int wheels, int wingspan)
            : base(regNumber, color, wheels)
        {
            Wingspan = wingspan;
        }
    }
}
