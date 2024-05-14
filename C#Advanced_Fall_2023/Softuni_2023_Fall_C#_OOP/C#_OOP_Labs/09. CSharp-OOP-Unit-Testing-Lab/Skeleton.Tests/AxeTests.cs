using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private IWeapon axe;
        private ITarget dummy;
        [SetUp]
        public void SetUp()
        {
            axe = new Axe(15, 100);
            dummy = new Dummy(100, 100);
        }
        [Test]
        public void When_Attack_LoseDurability()
        {
            int durabilityBefore = axe.DurabilityPoints;
            axe.Attack(dummy);
            Assert.Less(axe.DurabilityPoints, durabilityBefore);
        }
        [Test]
        public void When_AttackWithBrokenAxe_ThrowException()
        {
            axe = new Axe(15, 0);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);

            });
        }
    }
}