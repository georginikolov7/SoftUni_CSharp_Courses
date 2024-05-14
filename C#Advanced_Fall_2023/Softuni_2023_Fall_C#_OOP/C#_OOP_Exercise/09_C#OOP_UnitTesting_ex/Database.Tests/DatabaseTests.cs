namespace Database.Tests
{
    using Microsoft.Extensions.DependencyModel;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            int expectedResult = 2;
            database = new Database(1, 2);
            int actualResult = database.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void CreateDatabase_ShouldAddElementsCorrectly(params int[] data)
        {
            database = new Database(data);
            int[] actualResult = database.Fetch();
            Assert.AreEqual(data, actualResult);
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 6, 76, 1, 546, 546, 54, 6, 546, 54, 6, 546, 456, 54, 654, 6, 456, 54, 6)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)]
        public void CreateDatabase_ShouldThrowException_WhenCountIsMoreThan16(params int[] data)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
             {
                 database = new Database(data);

             });
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }

        [Test]
        public void RemoveMethod_Should_ReduceCountByOne()
        {
            database = new Database(1, 2, 3);
            int expected = 2;
            database.Remove();
            Assert.AreEqual(expected, database.Count);
        }
        [Test]
        public void RemoveMethod_ShouldRemoveOneElementAtTheLastIndex()
        {
            int[] expected = new int[] { 1, 2 };
            database = new Database(1,2,3);
            database.Remove();
            int[] actual = database.Fetch();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveMethod_Should_ThrowExceptionIfDatabase_IsEmpty()
        {
            database = new();
            InvalidOperationException ex= Assert.Throws<InvalidOperationException>(() => database.Remove());
            Assert.AreEqual("The collection is empty!", ex.Message);
        }

        [Test]
        [TestCase(1,2,3)]
        [TestCase()]
        public void FetchMethod_ShouldWorkCorrectly(params int[] nums)
        {
            
            database = new Database(nums);
            int[] actual= database.Fetch();
            Assert.AreEqual(nums, actual);
        }
    }
}
