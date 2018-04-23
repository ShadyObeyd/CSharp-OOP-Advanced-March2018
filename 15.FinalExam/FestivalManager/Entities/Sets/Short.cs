namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
        private const int AllowedHours = 0;
        private const int AllowedMinutes = 15;
        private const int AllowedSeconds = 0;

		public Short(string name) 
			: base(name, new TimeSpan(AllowedHours, AllowedMinutes, AllowedSeconds))
		{

		}
	}
}