namespace ConsoleApp.Vehicles
{
    internal class Bus: Vehicle
    {
        public int SeatQty { get; }
        public Bus(string regNumber, string color, int wheels, int seatQty)
            : base(regNumber, color, wheels)
        {
            SeatQty = seatQty;
        }

    }
}
