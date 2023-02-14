namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionerModifier = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionLitersPerKm)
            : base(fuelQuantity, fuelConsumptionLitersPerKm, TruckAirConditionerModifier)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * 0.95);
        }
    }
}
