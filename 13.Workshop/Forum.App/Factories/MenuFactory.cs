using System;
using System.Linq;
using System.Reflection;

public class MenuFactory : IMenuFactory
{
    private IServiceProvider serviceProvider;

    public MenuFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IMenu CreateMenu(string menuName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type menuType = assembly.GetTypes().FirstOrDefault(m => m.Name == menuName);

        if (menuType == null)
        {
            throw new InvalidOperationException("Menu not found!");
        }

        if (!typeof(IMenu).IsAssignableFrom(menuType))
        {
            throw new InvalidOperationException($"{menuType.Name} is not a menu!");
        }

        ParameterInfo[] ctorArgs = menuType.GetConstructors().First().GetParameters();

        object[] args = new object[ctorArgs.Length];

        for (int i = 0; i < args.Length; i++)
        {
            args[i] = this.serviceProvider.GetService(ctorArgs[i].ParameterType);
        }

        IMenu menu = (IMenu)Activator.CreateInstance(menuType, args);

        return menu;
    }
}