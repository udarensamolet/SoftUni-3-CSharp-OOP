using System;

namespace CarManager
{
    public class Car
    {
        private string _make;

        private string _model;

        private double _fuelConsumption;

        private double _fuelAmount;

        private double _fuelCapacity;

        private Car()
        {
            FuelAmount = 0;
        }

        public Car(string make, string model, double fuelConsumption, double fuelCapacity) 
            : this
        {
            Make = make;
            Model = model;
            FuelConsumption = fuelConsumption;
            FuelCapacity = fuelCapacity;
        }

        public string Make
        {
            get
            {
                return _make;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Make cannot be null or empty!");
                }

                _make = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be null or empty!");
                }

                _model = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return _fuelConsumption;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be zero or negative!");
                }

                _fuelConsumption = value;
            }
        }

        public double FuelAmount
        {
            get
            {
                return _fuelAmount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel amount cannot be negative!");
                }

                _fuelAmount = value;
            }
        }

        public double FuelCapacity
        {
            get
            {
                return _fuelCapacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel capacity cannot be zero or negative!");
                }

                _fuelCapacity = value;
            }
        }

        public void Refuel(double fuelToRefuel)
        {
            if (fuelToRefuel <= 0)
            {
                throw new ArgumentException("Fuel amount cannot be zero or negative!");
            }

            FuelAmount += fuelToRefuel;

            if (FuelAmount > FuelCapacity)
            {
                FuelAmount = FuelCapacity;
            }
        }

        public void Drive(double distance)
        {
            double fuelNeeded = (distance / 100) * FuelConsumption;

            if (fuelNeeded > FuelAmount)
            {
                throw new InvalidOperationException("You don't have enough fuel to drive!");
            }

            FuelAmount -= fuelNeeded;
        }
    }
}
