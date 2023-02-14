using VehiclesExtension.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            string[] carTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            double carFuelQuantity = double.Parse(carTokens[1]);
            double carFuelConsumptionLitersPerKm = double.Parse(carTokens[2]);
            double carTankCapacity = double.Parse(carTokens[3]);
            Vehicle car = new Car(carFuelQuantity, carFuelConsumptionLitersPerKm, carTankCapacity);


            string[] truckTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            double truckFuelQuantity = double.Parse(truckTokens[1]);
            double truckFuelConsumptionLitersPerKm = double.Parse(truckTokens[2]);
            double truckTankCapacity = double.Parse(carTokens[3]);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumptionLitersPerKm, truckTankCapacity);

            string[] busTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            double busFuelQuantity = double.Parse(busTokens[1]);
            double busFuelConsumptionLitersPerKm = double.Parse(busTokens[2]);
            double busTankCapacity = double.Parse(carTokens[3]);
            Vehicle bus = new Bus(busFuelQuantity, busFuelConsumptionLitersPerKm, busTankCapacity);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandTokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandTokens[0];
                string type = commandTokens[1];
                double amount = double.Parse(commandTokens[2]);

                if (command == "Drive")
                {
                    if (type == nameof(Car))
                    {
                        Console.WriteLine(car.Drive(amount));
                    }
                    else if (type == nameof(Truck))
                    {
                        Console.WriteLine(truck.Drive(amount));
                    }
                    else if (type == nameof(Bus))
                    {
                        Console.WriteLine(bus.Drive(amount));
                    }
                }
                else if(command == "DriveEmpty")
                {
                    if (type == nameof(Bus))
                    {
                        Console.WriteLine(bus.DriveEmpty(amount));
                    }
                }
                else if (command == "Refuel")
                {
                    if (type == nameof(Car))
                    {
                        car.Refuel(amount);
                    }
                    else if (type == nameof(Truck))
                    {
                        truck.Refuel(amount);
                    }
                }
                
            }

            Console.WriteLine($"{car.GetType().Name}: {car.FuelQuantity:f2}");
            Console.WriteLine($"{truck.GetType().Name}: {truck.FuelQuantity:f2}");
            Console.WriteLine($"{bus.GetType().Name}: {bus.FuelQuantity:f2}");
        }
    }
}
