using System;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type ammunitionType = assembly.GetType(name);

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(ammunitionType);

        return ammunition;
    }
}