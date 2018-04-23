using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type setType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            object[] ctorArgs = new object[] { name };

            ISet set = (ISet)Activator.CreateInstance(setType, ctorArgs);

            return set;
		}
	}




}
