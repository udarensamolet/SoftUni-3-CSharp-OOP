using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Daihatsu", "Applause", 5, 45);
        }

        [Test]
        [TestCase("", "Applause", 5, 45)]
        [TestCase(null, "Applause", 5, 45)]
        [TestCase("Daihatsu", "", 5, 45)]
        [TestCase("Daihatsu", null, 5, 45)]
        [TestCase("Daihatsu", "Applause", -1, 45)]
        [TestCase("Daihatsu", "Applause", 0, 45)]
        [TestCase("Daihatsu", "Applause", 5, -1)]
        [TestCase("Daihatsu", "Applause", 5, 0)]
        public void Ctr_ThrowsExceptionInvalidData_Test(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctr_CreatesCorrectInstance_Test()
        {
            car = new Car("Daihatsu", "Applause", 5, 45);
            Assert.AreEqual("Daihatsu", car.Make);
            Assert.AreEqual("Applause", car.Model);
            Assert.AreEqual(5, car.FuelConsumption);
            Assert.AreEqual(45, car.FuelCapacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void Refuel_ThrowsExceptionFuelToRefuelInvalidAmount_Test(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));
        }

        [Test]
        public void Refuel_IncreaseFuelAmountLessThanFuelCapacity_Test()
        {
            car.Refuel(10);
            Assert.AreEqual(10, car.FuelAmount);
        }

        [Test]
        public void Refuel_IncreaseFuelAmountMoreThanFuelCapacity_Test()
        {
            car.Refuel(50);
            Assert.AreEqual(45, car.FuelAmount);
        }

        [Test]
        public void Drive_ThrowsExceptionMoreFuelNeeded_Test()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(5000));
        }

        [Test]
        public void Drive_DecreaseFuelAmount_Test()
        {
            car.Refuel(45);
            car.Drive(100);
            Assert.AreEqual(40, car.FuelAmount);
        }

        [Test]
        public void FuelAmount_ThrowsException_WhenNegativeValueIsPassed_Test()
        {
            car.Refuel(45);
            double beforeDrive = car.FuelAmount;
            car.Drive(500);
            double afterDrive = car.FuelAmount;
            Assert.That(afterDrive, Is.LessThan(beforeDrive));
        }
    }
}