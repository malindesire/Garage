
namespace ConsoleApp
{
    internal class Manager
    {
        private readonly UI _ui;
        private readonly GarageHandler GarageHandler = new GarageHandler(15); // Assuming a garage with 15 spots

        public Manager()
        {
            _ui = new UI();
        }

        public void Run() 
        {
            _ui.ShowMainMenu();

            while (true)
            {
                var input = _ui.AskForInput("Select an option");
                if (input == "0")
                {
                    break;
                }
                switch (input)
                {
                    case "1":
                        GarageHandler.ShowAllParkedVehicles();
                        break;
                    case "2":
                        GarageHandler.ShowVehicleTypesAndCounts();
                        break;
                    case "3":
                        GarageHandler.ParkVehicle();
                        break;
                    case "4":
                        GarageHandler.RemoveVehicle();
                        break;
                    case "5":
                        GarageHandler.PopulateGarageWithVehicles(10);
                        break;
                    case "6":
                        GarageHandler.SearchVehicleByRegistrationNumber();
                        break;
                    case "7":
                        GarageHandler.SearchVehicleByProperty();
                        break;
                    default:
                        _ui.ShowMessage("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
