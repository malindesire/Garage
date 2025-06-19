using ConsoleApp.Vehicles;

namespace ConsoleApp.ConsoleUI
{
    internal interface IUI
    {
        int AskForInt(string prompt);
        int? AskForOptionalInt(string prompt);
        VehicleColor? AskForOptionalVehicleColor();
        VehicleType? AskForOptionalVehicleType();
        string AskForString(string prompt);
        VehicleColor AskForVehicleColor();
        VehicleType AskForVehicleType();
        void ShowMainMenu();
        void ShowMessage(string message);
    }
}