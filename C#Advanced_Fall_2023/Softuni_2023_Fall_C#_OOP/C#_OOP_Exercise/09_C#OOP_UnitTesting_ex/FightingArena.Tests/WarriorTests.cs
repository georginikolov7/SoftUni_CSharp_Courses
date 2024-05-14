namespace FightingArena.Tests
{
    using Microsoft.Extensions.DependencyModel;
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void WarriorContstructorShouldWorkCorrectly()
        {
            string expectedName = "Dimitrichko";
            int expectedDamage = 15;
            int expectedHealth = 50;

            Warrior warrior = new(expectedName, expectedDamage, expectedHealth);
            Assert.NotNull(warrior);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHealth, warrior.HP);
        }

        [Test]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void WarriorContstructorShouldThrowArgumentExceptionIfNameIsEmptyNullOrWhitespace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new(name, 35, 43);

            });
            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);

        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-42)]
        public void WarriorContstructorShouldThrowArgumentExceptionIfDamageIs0OrNegative(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {

                Warrior warrior = new("Pesho", damage, 23);

            });
            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }
        [Test]
        [TestCase(-32)]
        [TestCase(-1)]
        [TestCase(-42)]
        public void WarriorContstructorShouldThrowArgumentExceptionIfHPIsNegative(int hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {

                Warrior warrior = new("Pesho", 34, hp);

            });
            Assert.AreEqual("HP should not be negative!", exception.Message);
        }
        [Test]
        public void AttackMethodShouldWorkCorrectly()
        {
            int expectedAttackerHp = 85;
            int expectedDefenderHp = 80;
            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 15, 90);
            attacker.Attack(defender);
            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);

        }
        [Test]
        public void AttackMethod_ShouldThrowException_When_HPIsLessThanMinAttackHP()
        {
            InvalidOperationException ex= Assert.Throws<InvalidOperationException>(() =>
            {
                Warrior warrior = new("ajfkjh", 123, 20);
                Warrior enemy = new("Ivan", 67, 100);
                warrior.Attack(enemy);

            });
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);
        }
        [Test]
        public void AttackMethod_ShouldThrowException_When_EnemyHP_IsLessThanMinHP()
        {
            InvalidOperationException ex= Assert.Throws<InvalidOperationException>(() =>
            {
                Warrior warrior = new("ajfkjh", 123, 40);
                Warrior enemy = new("Ivan", 10, 20);
                warrior.Attack(enemy);
            });
            Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", ex.Message);
        }
        [Test]
        public void AttackMethod_ShouldThrowException_When_HealthIsLessThanEnemyDamage()
        {
            InvalidOperationException ex= Assert.Throws<InvalidOperationException>(() =>
            {
                Warrior warrior = new("ajfkjh", 50, 40);
                Warrior enemy = new("Ivan", 200, 35);
                warrior.Attack(enemy);
            });
            Assert.AreEqual("You are trying to attack too strong enemy", ex.Message);
        }
        [Test]
        public void AttackMethod_ShouldKillEnemy_When_DamageIsMoreThanEnemyHealth()
        {
            Warrior attacker = new("fedag", 200, 50);
            Warrior enemy = new("okjfda", 40, 100);
            attacker.Attack(enemy);
            Assert.AreEqual(0, enemy.HP);
        }
    }
}