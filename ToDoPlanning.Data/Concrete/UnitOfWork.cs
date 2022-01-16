using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Data.Abstract;
using ToDoPlanning.Data.Concrete.EntityFramework.Context;
using ToDoPlanning.Data.Concrete.EntityFramework.Repository;

namespace ToDoPlanning.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoPlanningContext _context;
        private IToDoProviderRepository _toDoProviderRepository;
        private IToDoTaskRepository _toDoTaskRepository;
        private IDeveloperRepository _developerRepository;
        private ITaskPlanRepository _taskPlanRepository;

        public UnitOfWork(ToDoPlanningContext context)
        {
            _context = context;
        }

        public IToDoProviderRepository ToDoProviders => _toDoProviderRepository ?? new EfToDoProviderRepository(_context);
        public IToDoTaskRepository ToDoTasks => _toDoTaskRepository ?? new EfToDoTaskRepository(_context);
        public IDeveloperRepository Developers => _developerRepository ?? new EfDeveloperRepository(_context);
        public ITaskPlanRepository TaskPlans => _taskPlanRepository ?? new EfTaskPlanRepository(_context);
             

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
