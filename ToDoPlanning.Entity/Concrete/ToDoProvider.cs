using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Shared.Entity.Abstract;

namespace ToDoPlanning.Entity.Concrete
{
    public class ToDoProvider : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ICollection<ToDoTask> ToDoTasks { get; set; }

    }
}
