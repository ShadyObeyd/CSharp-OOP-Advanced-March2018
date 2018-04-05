﻿using _03BarracksFactory.Contracts;

namespace _03.BarraksWars.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public abstract string Execute();

    }
}