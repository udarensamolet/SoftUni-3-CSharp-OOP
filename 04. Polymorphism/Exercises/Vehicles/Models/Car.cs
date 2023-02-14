namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CarAirConditionerModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionLitersPerKm) 
            : base(fuelQuantity, fuelConsumptionLitersPerKm, CarAirConditionerModifier)
        {
        }
    }
}
