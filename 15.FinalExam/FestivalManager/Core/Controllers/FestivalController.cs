namespace FestivalManager.Core.Controllers
{
	using System;
    using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "{0:d2}:{1:d2}";
        private const string RegisterSetMessage = "Registered {0} set";
        private const string PerformerSignedUp = "Registered performer {0}";
        private const string RegisteredSong = "Registered song {0} ({1})";
        private const string InvalidSetMessage = "Invalid set provided";
        private const string InvalidSongMessage = "Invalid song provided";
        private const string SongAddedSuccessfullyToSet = "Added {0} ({1}) to {2}";
        private const string InvalidPerformerMessage = "Invalid performer provided";
        private const string PerformedAddedToSet = "Added {0} to {1}";
        private const string SetOutputMessage = "--{0} ({1}):";
        private const string PerformerOutputMessage = "---{0} ({1})";
        private const string SongOutputMessage = "----{0} ({1})";
        private const string RepairedInstrumentsMessage = "Repaired {0} instruments";
        private const double MaxInstrumentWear = 100;
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;

		private readonly IStage stage;

		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.songFactory = new SongFactory();
		}

		public string RegisterSet(string[] args)
		{
            string setName = args[0];
            string setType = args[1];

            ISet set = this.setFactory.CreateSet(setName, setType);

            this.stage.AddSet(set);

            return string.Format(RegisterSetMessage, setType);
        }

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            List<string> instrumentNames = args.Skip(2).ToList();

            foreach (string instrumentName in instrumentNames)
            {
                IInstrument instrument = this.instrumentFactory.CreateInstrument(instrumentName);

                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(PerformerSignedUp, name);
        }

		public string RegisterSong(string[] args)
		{
            string songName = args[0];

            int hours = 0;
            string[] timeArgs = args[1].Split(':');

            int minutes = int.Parse(timeArgs[0]);
            int seconds = int.Parse(timeArgs[1]);

            TimeSpan songDuration = new TimeSpan(hours, minutes, seconds);

            ISong song = this.songFactory.CreateSong(songName, songDuration);

            this.stage.AddSong(song);

            string formatedDuration = string.Format(TimeFormat, minutes, seconds);

            return string.Format(RegisteredSong, songName, formatedDuration);
		}

		public string AddPerformerToSet(string[] args)
		{
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.Performers.Any(p => p.Name == performerName))
            {
                throw new InvalidOperationException(InvalidPerformerMessage);
            }

            if (!this.stage.Sets.Any(s => s.Name == setName))
            {
                throw new InvalidOperationException(InvalidSetMessage);
            }

            IPerformer performer = this.stage.Performers.FirstOrDefault(p => p.Name == performerName);
            ISet set = this.stage.Sets.FirstOrDefault(s => s.Name == setName);

            set.AddPerformer(performer);

            string result = string.Format(PerformedAddedToSet, performerName, setName);

            return result;
		}

		public string RepairInstruments(string[] args)
		{
			IInstrument[] instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < MaxInstrumentWear)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

            string result = string.Format(RepairedInstrumentsMessage, instrumentsToRepair.Length);

            return result;
		}

        public string ProduceReport()
        {
            StringBuilder result = new StringBuilder();

            TimeSpan timeSpan = TimeSpan.FromTicks(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            string festivalTotalLenght = $"Festival length: {string.Format(TimeFormat, (int)timeSpan.TotalMinutes, timeSpan.Seconds)}";

            result.AppendLine(festivalTotalLenght);

            foreach (ISet set in this.stage.Sets)
            {
                string setOutput = string.Format(SetOutputMessage, set.Name, string.Format(TimeFormat, (int)set.ActualDuration.TotalMinutes, set.ActualDuration.Seconds));

                result.AppendLine(setOutput);

                foreach (IPerformer performer in set.Performers.OrderByDescending(p => p.Age))
                {
                    IEnumerable<IInstrument> performerInstruments = performer.Instruments.OrderByDescending(i => i.Wear);

                    string performerOutput = string.Format(PerformerOutputMessage, performer.Name, string.Join(", ", performerInstruments));

                    result.AppendLine(performerOutput);
                }

                string songTotalInfo = string.Empty;

                if (!set.Songs.Any())
                {
                    songTotalInfo = "--No songs played";
                }
                else
                {
                    songTotalInfo = "--Songs played:";
                }

                result.AppendLine(songTotalInfo);

                foreach (ISong song in set.Songs)
                {
                    string songOutput = string.Format(SongOutputMessage, song.Name, string.Format(TimeFormat, song.Duration.Minutes, song.Duration.Seconds));

                    result.AppendLine(songOutput);
                }
            }

            return result.ToString().TrimEnd();
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.Sets.Any(s => s.Name == setName))
            {
                throw new InvalidOperationException(InvalidSetMessage);
            }

            if (!this.stage.Songs.Any(s => s.Name == songName))
            {
                throw new InvalidOperationException(InvalidSongMessage);
            }

            ISet set = this.stage.Sets.FirstOrDefault(s => s.Name == setName);

            ISong song = this.stage.Songs.FirstOrDefault(s => s.Name == songName);

            set.AddSong(song);

            string result = string.Format(SongAddedSuccessfullyToSet, songName, string.Format(TimeFormat, song.Duration.Minutes, song.Duration.Seconds), setName);

            return result;
        }
    }
}