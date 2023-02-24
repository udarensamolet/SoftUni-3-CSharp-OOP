using ExtendedDatabase;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person1;
        private Person person2;
        private Person person3;
        private Person person4;
        private Person person5;
        private Person person6;
        private Person person7;
        private Person person8;
        private Person person9;
        private Person person10;
        private Person person11;
        private Person person12;
        private Person person13;
        private Person person14;
        private Person person15;
        private Person person16;

        private ExtendedDatabase.ExtendedDatabase db;
        Person[] dataToBeAdded = new Person[15];
        Person[] wrongDataToBeAdded = new Person[17];

        [SetUp]
        public void Setup()
        {
            person1 = new Person(1, "udarensamolet1");
            person2 = new Person(2, "udarensamolet2");
            person3 = new Person(3, "udarensamolet3");
            person4 = new Person(4, "udarensamolet4");
            person5 = new Person(5, "udarensamolet5");
            person6 = new Person(6, "udarensamolet6");
            person7 = new Person(7, "udarensamolet7");
            person8 = new Person(8, "udarensamolet8");
            person9 = new Person(9, "udarensamolet9");
            person10 = new Person(10, "udarensamolet10");
            person11 = new Person(11, "udarensamolet11");
            person12 = new Person(12, "udarensamolet12");
            person13 = new Person(13, "udarensamolet13");
            person14 = new Person(14, "udarensamolet14");
            person15 = new Person(15, "udarensamolet15");
            person16 = new Person(16, "udarensamolet16");

            dataToBeAdded[0] = person1;
            dataToBeAdded[1] = person2;
            dataToBeAdded[2] = person3;
            dataToBeAdded[3] = person4;
            dataToBeAdded[4] = person5;
            dataToBeAdded[5] = person6;
            dataToBeAdded[6] = person7;
            dataToBeAdded[7] = person8;
            dataToBeAdded[8] = person9;
            dataToBeAdded[9] = person10;
            dataToBeAdded[10] = person11;
            dataToBeAdded[11] = person12;
            dataToBeAdded[12] = person13;
            dataToBeAdded[13] = person14;
            dataToBeAdded[14] = person15;

            wrongDataToBeAdded[0] = person1;
            wrongDataToBeAdded[1] = person2;
            wrongDataToBeAdded[2] = person3;
            wrongDataToBeAdded[3] = person4;
            wrongDataToBeAdded[4] = person5;
            wrongDataToBeAdded[5] = person6;
            wrongDataToBeAdded[6] = person7;
            wrongDataToBeAdded[7] = person8;
            wrongDataToBeAdded[8] = person9;
            wrongDataToBeAdded[9] = person10;
            wrongDataToBeAdded[10] = person11;
            wrongDataToBeAdded[11] = person12;
            wrongDataToBeAdded[12] = person13;
            wrongDataToBeAdded[13] = person14;
            wrongDataToBeAdded[14] = person15;

            db = new ExtendedDatabase.ExtendedDatabase(dataToBeAdded);
        }

        [Test]
        public void Ctor_CreateExtendedDatabase()
        {
            ExtendedDatabase.ExtendedDatabase newDb = new ExtendedDatabase.ExtendedDatabase(dataToBeAdded);
            Assert.AreEqual(15, newDb.Count, "Ctor is not working correctly");
        }

        [Test]
        public void AddRange_ExcedesCount_Test()
        {
            wrongDataToBeAdded[15] = person16;
            Person person17 = new Person(17, "udarensamolet17");
            wrongDataToBeAdded[16] = person17;
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(wrongDataToBeAdded));

        }

        [Test]
        public void Add_IncreaseCount_Test()
        {
            db.Add(person16);
            Assert.AreEqual(16, db.Count, "Count isn't increasing");
        }

        [Test]
        public void Add_ThrowExceptionWhenExcedesCount_Test()
        {
            db.Add(person16);
            Person person17 = new Person(17, "udarensamolet17");
            Assert.Throws<InvalidOperationException>(() => db.Add(person17));
        }

        [Test]
        public void Add_ThrowExceptionWhenAddingExistingUserUsername_Test()
        {
            Person person17 = new Person(17, "udarensamolet1");
            Assert.Throws<InvalidOperationException>(() => db.Add(person17));
        }

        [Test]
        public void Add_ThrowExceptionWhenAddingExistingUserId_Test()
        {
            Person person17 = new Person(1, "udarensamolet17");
            Assert.Throws<InvalidOperationException>(() => db.Add(person17));
        }

        [Test]
        public void Remove_CountDecreases()
        {
            db.Remove();
            Assert.AreEqual(14, db.Count);
        }

        [Test]
        public void Remove_ThrowsExceptionWhenCountIsEqualToZero_Test()
        {
            Person[] arrWithOneElement = new Person[1];
            arrWithOneElement[0] = person1;
            db = new ExtendedDatabase.ExtendedDatabase(arrWithOneElement);
            db.Remove();
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void FindByUsername_ReturnsPerson()
        {
            string name = "udarensamolet1";
            var expectedPerson = new Person(1, "udarensamolet1");
            var actualPerson = db.FindByUsername(name);
            Assert.AreEqual(expectedPerson.Id, actualPerson.Id, "Ids are not the same");
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName, "Names are not the same");
        }

        [Test]
        public void FindByUsername_ThrowsExceptionWithEmptyName_Test()
        {
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }

        [Test]
        public void FindByUsername_ThrowsExceptionMissingUserName()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("NoSuchUsername"));
        }

        [Test]
        public void FindById_ReturnsPerson()
        {
            int id = 1;
            var expectedPerson = new Person(1, "udarensamolet1");
            var actualPerson = db.FindById(id);
            Assert.AreEqual(expectedPerson.Id, actualPerson.Id, "Ids are not the same");
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName, "Names are not the same");
        }

        [Test]
        public void FindById_ThrowsExceptionWithNegativeId_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-3));
        }

        [Test]
        public void FindById_ThrowsExceptionMissingId_Test()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindById(19));
        }


    }
}