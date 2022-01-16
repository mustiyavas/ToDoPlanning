using Microsoft.Extensions.DependencyInjection;
using System;
using ToDoPlanning.Data.Abstract;
using ToDoPlanning.Data.Concrete;
using ToDoPlanning.Data.Concrete.EntityFramework.Context;
using ToDoPlanning.Service.Abstract;
using ToDoPlanning.Service.Concrete;

namespace ToDoPlanning.Service.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ToDoPlanningContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IProviderService, ProviderManager>();
            serviceCollection.AddScoped<IDeveloperService, DeveloperManager>();
            serviceCollection.AddScoped<IToDoTaskService, ToDoTaskManager>();
            serviceCollection.AddScoped<ITaskPlanService, TaskPlanManager>();
            return serviceCollection;
        }


    }
}
