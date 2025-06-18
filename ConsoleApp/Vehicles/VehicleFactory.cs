namespace ConsoleApp.Vehicles
{
    internal static class VehicleFactory
    {
        private static readonly Random _random = new Random();

        public static Vehicle GenerateRandomVehicle()
        { 
            string regNumber = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            VehicleColor color = (VehicleColor)_random.Next(0, Enum.GetValues(typeof(VehicleColor)).Length);
            VehicleType type = (VehicleType)_random.Next(0, Enum.GetValues(typeof(VehicleType)).Length);

            return type switch
            {
                VehicleType.Airplane => new Airplane(regNumber, color, _random.Next(20, 80)),
                VehicleType.Boat => new Boat(regNumber, color, _random.Next(2, 60)),
                VehicleType.Bus => new Bus(regNumber, color, _random.Next(20, 100)),
                VehicleType.Car => new Car(regNumber, color, _random.Next(2, 6)),
                VehicleType.Motorcycle => new Motorcycle(regNumber, color, _random.Next(45, 210)),
                _ => new Car(regNumber, color, _random.Next(2, 6))
            };
        }
    }
}
