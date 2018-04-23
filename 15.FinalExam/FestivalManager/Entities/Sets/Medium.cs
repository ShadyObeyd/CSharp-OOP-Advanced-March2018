namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private const int AllowedHours = 0;
        private const int AllowedMinutes = 40;
        private const int AllowedSeconds = 0;

        public Medium(string name)
			: base(name, new TimeSpan(AllowedHours, AllowedMinutes, AllowedSeconds))
		{
			this.Name=name;
		}
	}
}