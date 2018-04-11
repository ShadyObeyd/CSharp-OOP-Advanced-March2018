﻿using System.Collections.Generic;

public class Group : IAttackGroup
{
    private List<IAttacker> attackers;

    public Group()
    {
        this.attackers = new List<IAttacker>();
    }

    public void AddMember(IAttacker attacker)
    {
        this.attackers.Add(attacker);
    }

    public void GroupAttack()
    {
        foreach (IAttacker attacker in this.attackers)
        {
            attacker.Attack();
        }
    }

    public void GroupTarget(ITarget target)
    {
        foreach (IAttacker attacker in this.attackers)
        {
            attacker.SetTarget(target);
        }
    }
}