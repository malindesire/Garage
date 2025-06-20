﻿using ConsoleApp.ConsoleUI;
using ConsoleApp.Vehicles;

namespace ConsoleApp
{
    internal class Manager
    {
        private readonly IUI _ui;
        private readonly IGarageHandler _garageHandler = new GarageHandler(15); // Assuming a garage with 15 spots

        public Manager()
        {
            _ui = new UI();
        }

        public void Run() 
        {
            _ui.ShowMainMenu();

            while (true)
            {
                var input = _ui.AskForString("Select an option from the menu");
                if (input == "0")
                {
                    break;
                }
                switch (input)
                {
                    case "1":
                        ShowAllParkedVehicles();
                        break;
                    case "2":
                        ShowVehicleTypesAndCounts();
                        break;
                    case "3":
                        ParkVehicle();
                        break;
                    case "4":
                        RemoveVehicle();
                        break;
                    case "5":
                        PopulateGarageWithVehicles(10);
                        break;
                    case "6":
                        SearchVehicleByRegistrationNumber();
                        break;
                    case "7":
                        SearchVehicleByProperty();
                        break;
                    default:
                        _ui.ShowMessage("Invalid option, please try again.");
                        break;
                }
            }
        }

        private bool IsGarageFull()
        {
            if (_garageHandler.IsFull)
            {
                _ui.ShowMessage("The garage is full, cannot park any more vehicles.");
                return true;
            }
            return false;
        }

        private bool IsGarageEmpty()
        {
            if (_garageHandler.IsEmpty)
            {
                _ui.ShowMessage("The garage is empty, no vehicles to show.");
                return true;
            }
            return false;
        }

        private Vehicle CreateVehicle()
        {
            var regNumber = _ui.AskForString("Enter vehicle registration number");
            VehicleColor color = _ui.AskForVehicleColor();
            VehicleType vehicleType = _ui.AskForVehicleType();

            switch (vehicleType)
            {
                case VehicleType.Airplane:
                    int wingspan = _ui.AskForInt("Enter airplane wingspan");
                    return new Airplane(regNumber, color, wingspan);
                case VehicleType.Boat:
                    int length = _ui.AskForInt("Enter boat length");
                    return new Boat(regNumber, color, length);
                case VehicleType.Bus:
                    int seats = _ui.AskForInt("Enter number of seats");
                    return new Bus(regNumber, color, seats);
                case VehicleType.Motorcycle:
                    int cylinderVolume = _ui.AskForInt("Enter cylinder volume");
                    return new Motorcycle(regNumber, color, cylinderVolume);
                default:
                    int doors = _ui.AskForInt("Enter number of doors");
                    return new Car(regNumber, color, doors);
            }
        }

        private void ShowAllParkedVehicles()
        {
            if (IsGarageEmpty()) return; // Exit if the garage is empty

            _ui.ShowMessage("Vehicles parked in the garage:");

            var vehicles = _garageHandler.GetParkedVehicles();
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    _ui.ShowMessage($"{vehicle.GetType().Name} in {vehicle.Color} with registration number {vehicle.RegNumber}");
                }
            }
        }

        private void ShowVehicleTypesAndCounts()
        {
            if (IsGarageEmpty()) return; // Exit if the garage is empty

            var vehicleCounts = _garageHandler.GetVehicleTypeCount();

            foreach (var kvp in vehicleCounts)
            {
                _ui.ShowMessage($"{kvp.Key}: {kvp.Value} parked");
            }
        }

        private void ParkVehicle()
        {
            if (IsGarageFull()) return; // Exit if the garage is full
            Vehicle vehicle = CreateVehicle();

            bool parked = _garageHandler.Park(vehicle);

            if (parked)
            {
                _ui.ShowMessage($"Vehicle of type {vehicle.Type} with registration number {vehicle.RegNumber} parked successfully.");
            }
            else
            {
                _ui.ShowMessage("Garage is full, could not park the vehicle.");
            }

        }

        private void RemoveVehicle()
        {
            if (IsGarageEmpty()) return; // Exit if the garage is empty

            var regNumber = _ui.AskForString("Enter vehicle registration number to remove");
            var vehicle = _garageHandler.Remove(regNumber);
            if (vehicle == null)
            {
                _ui.ShowMessage("No vehicle found with that registration number.");
            }
            else
            {
                _ui.ShowMessage($"{vehicle.GetType().Name} with registration number {vehicle.RegNumber} removed from garage.");
            }

        }

        private void PopulateGarageWithVehicles(int quantity)
        {
            if (IsGarageFull()) return; // Exit if the garage is full

            _garageHandler.Populate(quantity);
            _ui.ShowMessage($"Garage populated with {quantity} vehicles.");

        }

        private void SearchVehicleByRegistrationNumber()
        {
            if (IsGarageEmpty()) return; // Exit if the garage is empty

            _ui.ShowMessage("Search for a vehicle by registration number.");
            string regNumber = _ui.AskForString("Registration Number");
            var vehicle = _garageHandler.SearchVehicle(regNumber);
            if (vehicle == null)
            {
                _ui.ShowMessage("No vehicle found with that registration number.");
            }
            else
            {
                _ui.ShowMessage($"Found vehicle: {vehicle.GetType().Name} with registration number {vehicle.RegNumber}.");
            }
        }

        private void SearchVehicleByProperty()
        {
            if (IsGarageEmpty()) return; // Exit if the garage is empty

            _ui.ShowMessage("Search for vehicles by property");
            VehicleColor? color = _ui.AskForOptionalVehicleColor();
            var wheels = _ui.AskForOptionalInt("Wheel Quantity, press Enter to skip");
            VehicleType? type = _ui.AskForOptionalVehicleType();

            var results = _garageHandler.SearchVehicles(color, wheels, type);

            if (!results.Any())
            {
                _ui.ShowMessage("No vehicles matched the criteria.");
            }
            else
            {
                _ui.ShowMessage($"Found {results.Count()} vehicles matching the criteria:");
                foreach (var v in results)
                {   
                    if (v == null) continue; // Skip null vehicles
                    _ui.ShowMessage($"{v.GetType().Name} with registration number {v.RegNumber}.");
                }
            }
        }
    }
}
