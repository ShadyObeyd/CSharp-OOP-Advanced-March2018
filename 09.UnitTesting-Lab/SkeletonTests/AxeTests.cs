using NUnit.Framework;

public class AxeTests
{
    private int axeDamage;
    private int axeDurability;
    int dummyHp;
    int dummyExp;
    IWeapon axe;
    ITarget dummy;

    [Test]
    public void AxeLosesDurability()
    {
        this.axeDamage = 5;
        this.axeDurability = 10;
        
        this.dummyHp = 10;
        this.dummyExp = 20;

        this.axe = new Axe(axeDamage, axeDurability);
        this.dummy = new Dummy(dummyHp, dummyExp);

        axe.Attack(dummy);

        int expectedDurability = 9;

        Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedDurability));
    }

    [Test]
    public void CannotAttackWithBrokenWeapon()
    {
        this.axeDamage = 5;
        this.axeDurability = 0;
        
        this.dummyHp = 10;
        this.dummyExp = 20;

        this.axe = new Axe(axeDamage, axeDurability);
       this.dummy = new Dummy(dummyHp, dummyExp);

        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}