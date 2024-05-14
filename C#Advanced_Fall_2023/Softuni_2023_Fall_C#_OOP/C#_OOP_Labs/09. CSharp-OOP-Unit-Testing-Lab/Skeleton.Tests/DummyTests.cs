using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void When_Attacked_LoseHealth()
        {
            Dummy dummy = new(100, 100);
            dummy.TakeAttack(20);
            Assert.Less(dummy.Health, 100);
        }

        [Test]
        [TestCase(100)]
        [TestCase(20)]
        public void When_Dead_ThrowExceptionIfAttacked(int attackPoints)
        {
            Dummy dummy = new(0, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(attackPoints);

            });
        }
        [Test]
        public void Dead_CanGive_Xp()
        {
            Dummy dummy = new(0, 100);

            int a = dummy.GiveExperience();
            Assert.That(a != default);
        }
        [Test]
        public void Alive_CannotGive_XP()
        {
            Dummy dummy = new(56, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                int a = dummy.GiveExperience();

            });

        }
    }
}