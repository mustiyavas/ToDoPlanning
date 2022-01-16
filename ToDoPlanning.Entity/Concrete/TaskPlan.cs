using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Shared.Entity.Abstract;

namespace ToDoPlanning.Entity.Concrete
{
    public class TaskPlan : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalHour { get; set; }
        public int TotalWeek { get; set; }        
        public DateTime StartDate { get; set; }        
        public DateTime EndDate { get; set; }        
        public List<ToDoTask> ToDoTasks { get; set; }
    }
}
