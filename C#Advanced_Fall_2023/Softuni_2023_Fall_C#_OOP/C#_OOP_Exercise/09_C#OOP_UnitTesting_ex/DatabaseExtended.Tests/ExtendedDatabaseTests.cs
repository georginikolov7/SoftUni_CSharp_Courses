namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using System;
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection.Metadata;

    [TestFixture]
    public class ExtendedDatabaseTests
    {

        [Test]
        public void Constructor_ShouldWorkCorrectly()
        {
            Database database = new Database(new Person(42, "Gosho"), new Person(21, "Pesho"));
            Assert.AreEqual(2, database.Count);
        }
        [Test]
        public void Constructor_ShouldThrowExceptionIfPeopleAreMoreThan16()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Database database = new Database(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            });
            Assert.AreEqual("Provided data length should be in range [0..16]!", ex.Message);
        }
        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            Database database = new();
            Assert.AreEqual(0, database.Count);
            database.Add(new Person(12, "Ivan"));
            Assert.AreEqual(1, database.Count);
        }
        public void AddMethod_ShouldThrowException_WhenCountIs16()
        {
            Database database = new Database(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                database.Add(new Person(42, "Ivan"));

            });
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }
        [Test]
        public void AddMethod_ShouldThrowException_WhenWeTryToAddAPersonWhoseNameAlreadyExists()
        {
            Database database = new Database(new Person(42, "Ivan"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(21, "Ivan"));
            });
            Assert.AreEqual("There is already user with this username!", ex.Message);
        }
        [Test]
        public void AddMethod_ShouldThrowException_WhenWeTryToAddAPersonWhoseIdAlreadyExists()
        {
            Database database = new Database(new Person(42, "Pesho"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(42, "Ivan"));
            });
            Assert.AreEqual("There is already user with this Id!", ex.Message);
        }
        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            Database database = new Database(new Person(42, "Ivan"), new Person(21, "Dragan"));
            database.Remove();
            Assert.AreEqual(1, database.Count);
        }
        [Test]
        public void RemoveMethod_ShouldThrowException_WhenDatabaseIsEmpty()
        {
            Database database = new();
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });

        }
        [Test]
        public void FindByUsernameShouldWorkCorrectly()
        {
            Person person = new(42, "Dimitrichko");
            Database database = new Database(person, new Person(69, "Ebach"));
            Person found = database.FindByUsername(person.UserName);
            Assert.AreEqual(person, found);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ShouldThrowException_WhenUsernameParamIsNull(string name)
        {

            Database database = new Database(new Person(69, "Ebach"));
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(name);
            });
            Assert.AreEqual("Value cannot be null. (Parameter 'Username parameter is null!')", ex.Message);
        }
        [Test]
        public void FindByUsername_ShouldThrowException_WhenPersonIsNotInDB()
        {
            Person person = new(42, "Petar");
            Database database = new Database(person, new Person(69, "Ebach"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Drisho");
            });
            Assert.AreEqual("No user is present by this username!", ex.Message);
        }

        [Test]
        public void FindByIDShouldWorkCorrectly()
        {
            Person person = new(42, "Dimitrichko");
            Database database = new Database(person, new Person(69, "Ebach"));
            Person found = database.FindById(person.Id);
            Assert.AreEqual(person, found);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-29)]
        public void FindById_ShouldThrowException_WhenparamIsNegative(int id)
        {

            Database database = new Database(new Person(69, "Ebach"));
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-5);
            });
            Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'Id should be a positive number!')", ex.Message);
        }
        [Test]
        public void FindById_ShouldThrowException_WhenPersonIsNotInDB()
        {
            Person person = new(42, "Petar");
            Database database = new Database(person, new Person(69, "Ebach"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(32);
            });
            Assert.AreEqual("No user is present by this ID!", ex.Message);
        }
    }
}