using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Data.Abstract;
using ToDoPlanning.Entity.Concrete;
using ToDoPlanning.Shared.Data.Concrete.EntityFramework;

namespace ToDoPlanning.Data.Concrete.EntityFramework.Repository
{
    public class EfDeveloperRepository : EfEntityRepositoryBase<Developer>, IDeveloperRepository
    {
        public EfDeveloperRepository(DbContext context) : base(context)
        {
        }
    }
}
