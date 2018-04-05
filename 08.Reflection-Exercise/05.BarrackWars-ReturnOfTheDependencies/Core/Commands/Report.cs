using _03BarracksFactory.Contracts;

namespace _03.BarraksWars.Core.Commands
{
    public class Report : Command
    {
        [Inject]
        private IRepository repository;

        public Report(string[] data, IRepository repository) 
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
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
