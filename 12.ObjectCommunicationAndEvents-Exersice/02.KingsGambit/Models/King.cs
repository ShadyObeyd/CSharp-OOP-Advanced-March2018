using System;
using System.Collections.Generic;

public class King : Unit, IAttackable
{
    public event GetAttackedEventHandler GetAttackedEvent;

    public King(string name, ICollection<Subject> subjects) : base(name)
    {
        this.Subjects = subjects;
    }

    public ICollection<Subject> Subjects { get; private set; }

    public void GetAttacked()
    {
        Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

        if (this.GetAttackedEvent != null)
        {
            this.GetAttackedEvent.Invoke();
        }
    }

    public void AddSubject(Subject subject)
    {
        this.Subjects.Add(subject);
        this.GetAttackedEvent += subject.ReactToAttack;
    }
    
    public void KillSubject(Subject subject)
    {
        this.Subjects.Remove(subject);
    }
}