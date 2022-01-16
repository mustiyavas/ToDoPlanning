using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Shared.Entity.Abstract;

namespace ToDoPlanning.Entity.Concrete
{
    public class Developer : EntityBase, IEntity
    {
        public string Name { get; set; }
        public int Hour { get; set; }
        public int Level { get; set; }
        public int HourlyEfficiency { get { return Hour * Level; } }
        public int WeeklyEfficiency { get { return HourlyEfficiency * 45; } }

        public int Remaining { get; set; }
        public int CalendarWeek { get; set; } = 1;
        public ICollection<ToDoTask> ToDoTasks { get; set; }
    }
}
