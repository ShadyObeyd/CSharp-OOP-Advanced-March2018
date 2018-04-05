using System;
using _03BarracksFactory.Contracts;

namespace _03.BarraksWars.Core.Commands
{
    public class Retire : Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }


        public override string Execute()
        {
            string unitType = this.Data[1];

            string result = string.Empty;

            try
            {
                this.Repository.RemoveUnit(unitType);

                result = $"{unitType} retired!";
            }
            catch (Exception)
            {
                result = "No such units in repository.";
            }

            return result;
        }
    }
}
