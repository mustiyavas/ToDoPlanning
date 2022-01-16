using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlanning.Shared.Entity.Abstract
{
    public abstract class EntityBase
    {
        public virtual int ID { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; 
        public virtual bool IsActive { get; set; } = true;
    }
}
