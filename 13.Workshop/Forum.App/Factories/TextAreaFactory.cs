﻿using System;
using System.Linq;
using System.Reflection;

public class TextAreaFactory : ITextAreaFactory
{
    public ITextInputArea CreateTextArea(IForumReader reader, int x, int y, bool isPost = true)
    {
        Type commandType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
            .Contains(typeof(ITextInputArea))
            && !t.IsAbstract)
            .FirstOrDefault();

        if (commandType == null)
        {
            throw new InvalidOperationException("TextArea not found!");
        }

        object[] args = new object[] { reader, x, y, isPost };

        ITextInputArea commandInstance = (ITextInputArea)Activator.CreateInstance(commandType, args);

        return commandInstance;
    }
}