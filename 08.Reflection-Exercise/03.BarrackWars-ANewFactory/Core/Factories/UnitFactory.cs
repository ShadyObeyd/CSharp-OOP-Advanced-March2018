namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (type == null)
            {
                throw new ArgumentException("Invalid Unit!");
            }

            if (!typeof(IUnit).IsAssignableFrom(type))
            {
                throw new ArgumentException($"{unitType} is not a valid unit!");
            }

            IUnit classInstance = (IUnit)Activator.CreateInstance(type);

            return classInstance;
        }
    }
}
