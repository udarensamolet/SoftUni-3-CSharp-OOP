namespace VehiclesExtension.Models
{
    public abstract class Vehicle
    {
        private double _tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumptionLitersPerKm, double tankCapacity, double airConditionerModifier)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionLitersPerKm = fuelConsumptionLitersPerKm;
            TankCapacity = tankCapacity;
            AirConditionerModifier = airConditionerModifier;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionLitersPerKm { get; private set; }
        public double AirConditionerModifier { get; private set; }
        public double TankCapacity
        {
            get => _tankCapacity;
            private set
            {
                if (value < FuelQuantity)
                {
                    Console.WriteLine($"Cannot fit {FuelQuantity} fuel in the tank");
                    _tankCapacity = 0;
                }
                _tankCapacity = value;
            }
        }


        public virtual string Drive(double distance)
        {
            double requiredFuel = distance * (FuelConsumptionLitersPerKm + AirConditionerModifier);
            if (FuelQuantity < requiredFuel)
            {

                return $"{GetType().Name} needs refueling";
            }
            FuelQuantity -= requiredFuel;
            return $"{GetType().Name} travlled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            double requiredFuel = distance * (FuelConsumptionLitersPerKm);
            if (FuelQuantity < requiredFuel)
            {

                return $"{GetType().Name} needs refueling";
            }
            FuelQuantity -= requiredFuel;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (FuelQuantity + fuelAmount > _tankCapacity)
                {
                    Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
                }
                else
                {
                    FuelQuantity += fuelAmount;
                }
            }
        }
    }
}
