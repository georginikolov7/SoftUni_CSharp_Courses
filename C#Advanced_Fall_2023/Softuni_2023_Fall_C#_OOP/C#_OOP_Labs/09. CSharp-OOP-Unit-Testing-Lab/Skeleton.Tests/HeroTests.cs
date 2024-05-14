using Moq;
using NUnit.Framework;


namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        private Mock<IWeapon> weaponMock = new Mock<IWeapon>();
        private Mock<ITarget> targetMock = new Mock<ITarget>();
        private Hero hero;
        [SetUp]
        public void Setup()
        {
            targetMock.Setup(t=>t.IsDead()).Returns(true);
            targetMock.Setup(t => t.GiveExperience()).Returns(42);
            IWeapon weapon = weaponMock.Object;
            ITarget target = targetMock.Object;
            hero = new Hero(weapon, target);
        }
        [Test]
        public void WhenAttackTargetDies_ReceiveXP()
        {
            int expectedXP = 42;
            hero.Attack();
            Assert.AreEqual(expectedXP, hero.XP);
        }
    }
}
