namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of vehicles to populate the garage
            List<Vehicle> initialVehicles = new List<Vehicle>
            {
                new Car("ABC123", "Red", 4, 5),
                new Motorcycle("XYZ789", "Blue", 2, true),
                new Bus("DEF456", "Yellow", 6, 50),
                new Car("GHI789", "Black", 4, 5),
                new Motorcycle("JKL012", "Green", 2, true),
                new Bus("MNO345", "White", 6, 50),
                new Car("PQR678", "Silver", 4, 5),
                new Motorcycle("STU901", "Purple", 2, true),
                new Bus("VWX234", "Orange", 6, 50)
            };

            // Instantiate a new Garage object with a capacity of 100
            Garage<Vehicle> garage = new Garage<Vehicle>(100);

            // Populate the garage with the initial vehicles
            garage.PopulateGarage(initialVehicles);

            // Display the menu
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Search Vehicles");
                Console.WriteLine("2. Exit Program");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SearchForVehicle(garage);
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        break;
                }
            }
        }

        static void SearchForVehicle(Garage<Vehicle> garage)
        {
            Console.Write("Enter registration: ");
            string searchRegistrationNumber = Console.ReadLine();

            // Search for the vehicle with the provided registration number
            Vehicle foundVehicle = garage.FindVehicle(searchRegistrationNumber);
            if (foundVehicle != null)
            {
                Console.WriteLine($"Vehicle with registration number {searchRegistrationNumber} found:\n" +
                    $"Registration Number: {foundVehicle.RegistrationNumber}\n" +
                    $"Color: {foundVehicle.Color}\n" +
                    $"Number of Wheels: {foundVehicle.NumberOfWheels}");

                // Check if the found vehicle is a car and display its additional property
                if (foundVehicle is Car)
                {
                    Car foundCar = (Car)foundVehicle;
                    Console.WriteLine($"Number of Seats: {foundCar.NumberOfSeats}");
                }
            }
            else
            {
                Console.WriteLine($"No vehicle found with registration number {searchRegistrationNumber}");
            }
        }
    }
}
