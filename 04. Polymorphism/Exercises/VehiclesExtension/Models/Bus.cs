namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionerModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionLitersPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLitersPerKm, tankCapacity, AirConditionerModifier)
        {
        }

        
    }
}
