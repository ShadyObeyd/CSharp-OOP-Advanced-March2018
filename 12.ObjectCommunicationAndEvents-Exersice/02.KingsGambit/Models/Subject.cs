using System;

public abstract class Subject : Unit, IKillable
{
    protected Subject(string name) : base(name)
    {
        this.IsAlive = true;
    }

    public bool IsAlive { get; protected set; }

    public void Die()
    {
        this.IsAlive = false;
    }

    public abstract void ReactToAttack();
}