namespace ConsoleApp.Vehicles
{
    internal class Boat : Vehicle
    {
        public int Length { get; }
        public Boat(string regNumber, VehicleColor color, int length)
            : base(VehicleType.Boat, regNumber, color, wheels: 0)
        {
            Length = length;
        }
    }
}
