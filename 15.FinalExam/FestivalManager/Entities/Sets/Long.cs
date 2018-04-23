using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        private const int AllowedHours = 1;
        private const int AllowedMinutes = 0;
        private const int AllowedSeconds = 0;

        public Long(string name) 
            : base(name, new TimeSpan(AllowedHours, AllowedMinutes, AllowedSeconds))
        {

        }
    }
}
