using System;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type soldierType = assembly.GetType(soldierTypeName);

        object[] args = new object[] { name, age, experience, endurance };

        ISoldier soldier = (ISoldier)Activator.CreateInstance(soldierType, args);

        return soldier;
    }
}
