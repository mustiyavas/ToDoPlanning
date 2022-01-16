using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Entity.Concrete;
using ToDoPlanning.Shared.Data.Abstract;

namespace ToDoPlanning.Data.Abstract
{
    public interface IDeveloperRepository : IEntityRepository<Developer>
    {
    }
}
