namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }
        [Test]
        public void Constructor_ShouldWorkCorrectly()
        {

            Assert.That(arena, Is.Not.Null);
        }
        [Test]

        public void Enroll_ShouldAdd_Warriors_ToCollection()
        {
            Warrior warrior = new("ajfdk", 56, 23);

            int expectedCount = arena.Count + 1;
            arena.Enroll(warrior);
            Assert.AreEqual(expectedCount, arena.Count);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }
        [Test]
        public void Arena_Count_ShouldWorkCorrectly()
        {
            int expectedCount = 1;
            arena.Enroll(new Warrior("adsf", 43, 23));
            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedCount,arena.Count);
        }
        [Test]
        public void Enroll_ShouldThrow_InvalidOperationException_WhenWeTryToAddAWarriorWhichIsAlreadyInTheCollection()
        {
            arena.Enroll(new Warrior("Pesho", 10, 10));
            InvalidOperationException ex=Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Pesho", 11, 10));

            });
            Assert.AreEqual("Warrior is already enrolled for the fights!", ex.Message);
        }
        [Test]
        public void Fight_ShouldWorkCorrectly()
        {
            Warrior atacker = new("ivan", 20, 100);
            Warrior enemy = new("Petran", 10, 90);
            arena.Enroll(atacker);
            arena.Enroll(enemy);
            int expectedAttackerHp = 90;
            int expectedEnemyHp = 70;
            arena.Fight("ivan", "Petran");
            Assert.AreEqual(expectedAttackerHp, atacker.HP);
            Assert.AreEqual(expectedEnemyHp, enemy.HP);
        }

        [Test]
        public void ArenaFight_ShouldThrowException_IfAttackerIsNotInCollection()
        {
            string attackerName = "Ivo";
            arena.Enroll(new Warrior("Pesho", 10, 10));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName, "Pesho");

            });
            Assert.AreEqual($"There is no fighter with name {attackerName} enrolled for the fights!", ex.Message);
        }
        [Test]
        public void ArenaFight_ShouldThrowException_IfEnemyIsNotInCollection()
        {
            string enemyName = "Ivo";
            arena.Enroll(new Warrior("Pesho", 10, 10));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho",enemyName);

            });
            Assert.AreEqual($"There is no fighter with name {enemyName} enrolled for the fights!", ex.Message);
        }

    }
}
