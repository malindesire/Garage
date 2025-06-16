namespace ConsoleApp.Vehicles
{
    internal class Boat : Vehicle
    {
        public int Length { get; }
        public Boat(string regNumber, string color, int wheels, int length)
            : base(regNumber, color, wheels)
        {
            Length = length;
        }
    }
}
