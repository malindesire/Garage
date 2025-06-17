
namespace ConsoleApp
{
    internal class Manager
    {
        private readonly UI _ui;

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

        private void SearchVehicleByProperty()
        {
            throw new NotImplementedException();
        }

        private void SearchVehicleByRegistrationNumber()
        {
            throw new NotImplementedException();
        }

        private void PopulateGarageWithVehicles(int v)
        {
            throw new NotImplementedException();
        }

        private void RemoveVehicle()
        {
            throw new NotImplementedException();
        }

        private void ParkVehicle()
        {
            throw new NotImplementedException();
        }

        private void ShowVehicleTypesAndCounts()
        {
            throw new NotImplementedException();
        }

        private void ShowAllParkedVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
