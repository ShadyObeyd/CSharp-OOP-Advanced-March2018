using System;

public class Footman : Subject
{
    public Footman(string name) : base(name)
    {

    }

    public override void ReactToAttack()
    {
        if (this.IsAlive)
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is panicking!");
        }
    }
}