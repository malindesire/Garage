using ConsoleApp.Vehicles;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Tests")] // Allow unit tests to access internal members of this assembly

namespace ConsoleApp
{
    // Represents a parking spot in the parking lot
    // Each spot has a unique number and can either be occupied by a vehicle or not
    internal class Spot
    {
        // TODO: Make sure spot number is unique across all spots.
        public int Number { get; } // Spot number, unique identifier for the spot
        public Vehicle? ParkedVehicle { get; private set; }

        public bool IsOccupied => ParkedVehicle != null;

        public Spot(int number)
        {
            Number = number;
        }

        public bool Park(Vehicle vehicle)
        {
            if (IsOccupied)
            {
                return false; // Spot already taken
            }

            ParkedVehicle = vehicle;
            return true;
        }

        public void Vacate()
        {
            ParkedVehicle = null;
        }
    }
}
