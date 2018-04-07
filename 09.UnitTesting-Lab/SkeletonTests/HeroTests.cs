using Moq;
using NUnit.Framework;

public class HeroTests
{
    [Test]
    public void HeroGainsExpAfterKill()
    {
        int fakeTargetHp = 0;
        int fakeTargetExpToGive = 10;

        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(t => t.Health).Returns(fakeTargetHp);
        fakeTarget.Setup(t => t.GiveExperience()).Returns(fakeTargetExpToGive);
        fakeTarget.Setup(t => t.IsDead()).Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(fakeTargetExpToGive));
    }
}