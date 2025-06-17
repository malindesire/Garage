using ConsoleApp;
using ConsoleApp.Vehicles;

Manager manager = new Manager();
manager.Run();

//var airplane = new Airplane("ABC123", "white", 5, 60);
//var boat = new Boat("DEF123", "black", 0, 55);
//var bus = new Bus("GHI123", "green", 8, 35);
//var car = new Car("JKL123", "red", 4, 2);
//var motorcycle = new Motorcycle("MNO123", "yellow", 2, 125);

//var garage = new Garage<Spot>(15, number => new Spot(number));

// Spot test = (Spot)(from spot in garage
//           where spot.IsOccupied == false
//         select spot);

//garage.Spots[0].Park(airplane);
//garage.Spots[1].Park(boat);
//garage.Spots[2].Park(bus);
//garage.Spots[3].Park(car);
//garage.Spots[4].Park(motorcycle);

//foreach (var spot in garage)
//{
//    Console.WriteLine($"Spot {spot.Number}: {(spot.IsOccupied ? "Occupied with a " + spot.ParkedVehicle?.Color + " " + spot.ParkedVehicle?.ToString()  : "Available")}");
//}