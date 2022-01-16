using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Shared.Entity.Abstract;

namespace ToDoPlanning.Entity.Concrete
{
    public class ToDoTask : EntityBase, IEntity
    {
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public int TaskCost { get { return Difficulty * Duration; } }
        public string ExternalID { get; set; }
        public int ToDoProviderID { get; set; }
        public bool isPlanned { get; set; } = false;
        public ToDoProvider ToDoProvider { get; set; }
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
        public int TaskPlanID { get; set; }
        public TaskPlan TaskPlan { get; set; }

    }
}
