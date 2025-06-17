namespace ConsoleApp.Vehicles
{
    internal class Bus: Vehicle
    {
        public int SeatQty { get; }
        public Bus(string regNumber, string color, int seatQty)
            : base(regNumber, color, wheels: 8)
        {
            SeatQty = seatQty;

        }

    }
}
