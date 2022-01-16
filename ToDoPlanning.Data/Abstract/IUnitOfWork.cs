using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlanning.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IToDoProviderRepository ToDoProviders { get; } // unitofwork.ToDoProviders

        IToDoTaskRepository ToDoTasks { get; }

        IDeveloperRepository Developers { get; }
        ITaskPlanRepository TaskPlans { get; }

        Task<int> SaveAsync();
    }
}
