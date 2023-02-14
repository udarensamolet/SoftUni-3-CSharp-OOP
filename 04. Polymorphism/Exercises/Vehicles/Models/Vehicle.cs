namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionLitersPerKm, double airConditionerModifier)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionLitersPerKm = fuelConsumptionLitersPerKm;
            AirConditionerModifier = airConditionerModifier;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionLitersPerKm { get; private set; }

        public double AirConditionerModifier { get; private set; }
       
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
        public virtual void Refuel(double fuelAmount)
        {
            FuelQuantity += fuelAmount;
        }
    }
}
