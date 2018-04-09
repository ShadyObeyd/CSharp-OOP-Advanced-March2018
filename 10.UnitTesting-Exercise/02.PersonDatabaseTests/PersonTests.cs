using NUnit.Framework;

public class PersonTests
{
    private string personName = "Balkan";
    private long personId = 95231346321348;
    private Person person;

    [SetUp]
    public void SetUpPerson()
    {
        this.person = new Person(this.personName, this.personId);
    }

    [Test]
    public void TestPersonName()
    {
        Assert.That(this.person.Name, Is.EqualTo(this.personName));
    }

    [Test]
    public void TestPersonId()
    {
        Assert.That(this.person.Id, Is.EqualTo(this.personId));
    }
}