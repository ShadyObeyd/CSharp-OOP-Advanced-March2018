using NUnit.Framework;

public class DummyTests
{
    private int dummyHp;
    private int dummyExp;
    private int attackPoints;
    ITarget dummy;

    [Test]
    public void DummyLosesHpWhenAttacked()
    {
        this.dummyHp = 25;
        this.dummyExp = 20;
        this.attackPoints = 10;

        dummy = new Dummy(dummyHp, dummyExp);

        dummy.TakeAttack(attackPoints);

        Assert.That(dummy.Health, Is.EqualTo(15));
    }

    [Test]
    public void DummyThrowsExceptopnIfDead()
    {
        this.dummyHp = 0;
        this.dummyExp = 20;
        this.attackPoints = 10;

        this.dummy = new Dummy(dummyHp, dummyExp);

        Assert.That(() => dummy.TakeAttack(attackPoints), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyGivesXp()
    {
        this.dummyHp = 0;
        this.dummyExp = 20;

        this.dummy = new Dummy(dummyHp, dummyExp);

        Assert.That(dummy.GiveExperience(), Is.EqualTo(dummyExp));
    }

    [Test]
    public void AliveDummyCannotGiveXp()
    {
        this.dummyHp = 25;
        this.dummyExp = 20;

        this.dummy = new Dummy(dummyHp, dummyExp);

        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}