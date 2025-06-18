namespace ConsoleApp.Vehicles
{
    internal class Bus: Vehicle
    {
        public int SeatQty { get; }
        public Bus(string regNumber, VehicleColor color, int seatQty)
            : base(VehicleType.Bus, regNumber, color, wheels: 8)
        {
            SeatQty = seatQty;

        }

    }
}
