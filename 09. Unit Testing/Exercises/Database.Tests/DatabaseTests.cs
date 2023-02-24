using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database db;

        [SetUp]
        public void Setup()
        {
            db = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        }

        [Test]
        public void Add_CountIncreases_Test()
        {
            db.Add(16);
            Assert.That(db.Count, Is.EqualTo(16), "Db doesn't add elements");
        }

        [Test]
        public void Add_ThrowsExceptionWhenExceededCount_Test()
        {
            db.Add(16);
            Assert.Throws<InvalidOperationException>(() => db.Add(17), "Db doens't throw an exception");
        }

        [Test]
        public void Remove_CountDecreases_Test()
        {
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(14), "Db doesn't remove elements");
        }
        
        [Test]
        public void Remove_ThrowsExceptionWhenCountReachesZeto_Test()
        {
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            Assert.Throws<InvalidOperationException>(() => db.Remove(), "Db doens't throw an exception");
        }

        [Test]
        public void Fetch_ArraysAreEquivalent()
        {
            int[] expectedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] actualArray = db.Fetch();
            Assert.AreEqual(expectedArray, actualArray);
        }
    }
}