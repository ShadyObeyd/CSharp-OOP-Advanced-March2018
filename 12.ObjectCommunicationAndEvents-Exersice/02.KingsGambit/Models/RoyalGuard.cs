using System;

public class RoyalGuard : Subject
{
    public RoyalGuard(string name) : base(name)
    {

    }

    public override void ReactToAttack()
    {
        if (this.IsAlive)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}