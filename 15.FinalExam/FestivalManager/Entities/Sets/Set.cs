namespace FestivalManager.Entities.Sets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public abstract class Set : ISet
    {
        private const string InvalidSongMessage = "Song is over the set limit!";
        private List<IPerformer> performers;
        private List<ISong> songs;

        protected Set(string name, TimeSpan maxDuration)
        {
            this.Name = name;
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
            this.MaxDuration = maxDuration;
        }

        public string Name { get; protected set; }

        public TimeSpan MaxDuration { get; protected set; }

        public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers
        {
            get
            {
                return this.performers;
            }
        }

        public IReadOnlyCollection<ISong> Songs
        {
            get
            {
                return this.songs;
            }
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (this.ActualDuration + song.Duration > this.MaxDuration)
            {
                throw new InvalidOperationException(InvalidSongMessage);
            }

            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            if (!this.performers.Any() || !this.songs.Any() || this.performers.Any(p => p.Instruments.Any(i => i.IsBroken)))
            {
                return false;
            }

            return true;
        }
    }
}