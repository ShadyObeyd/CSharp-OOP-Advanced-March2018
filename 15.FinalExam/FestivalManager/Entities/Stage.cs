﻿namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(p => p.Name == name);

            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(s => s.Name == name);

            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(s => s.Name == name);

            return song;
        }

        public bool HasPerformer(string name)
        {
            if (this.performers.Any(p => p.Name == name))
            {
                return true;
            }

            return false;
        }

        public bool HasSet(string name)
        {
            if (this.sets.Any(s => s.Name == name))
            {
                return true;
            }

            return false;
        }

        public bool HasSong(string name)
        {
            if (this.songs.Any(s => s.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
