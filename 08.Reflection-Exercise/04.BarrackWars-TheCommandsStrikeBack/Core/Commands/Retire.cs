using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _03BarracksFactory.Contracts;

namespace _03.BarraksWars.Core.Commands
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {

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
