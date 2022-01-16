
using Microsoft.Extensions.DependencyInjection;
using System;
using ToDoPlanning.Service.Abstract;
using ToDoPlanning.Service.AutoMapper.Profiles;
using ToDoPlanning.Service.Extension;
using ToDoPlanning.Shared.Utility.Results.ComplexTypes;

namespace ToDoPlanning.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAutoMapper(typeof(ToDoProviderProfile), typeof(ToDoTaskProfile), typeof(DeveloperProfile), typeof(TaskPlanProfile));
            serviceCollection.LoadMyServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var providerService = serviceProvider.GetService<IProviderService>();

            var toDoProviderList = providerService.GetAllToDoProviderByActive();

            if (toDoProviderList.Result.ResultStatus == ResultStatus.Success)
            {
                var toDoTaskService = serviceProvider.GetService<IToDoTaskService>();
                var toDoTasksFromProvider = toDoTaskService.GetAllFromProvider(toDoProviderList.Result.Data);

                if(toDoTasksFromProvider.Result.ResultStatus == ResultStatus.Success)
                {
                    var addAllTodoTaskResult = toDoTaskService.AddAllFromProvider(toDoTasksFromProvider.Result.Data);

                    Console.WriteLine(addAllTodoTaskResult.Result.Message);
                }
                else
                {
                    Console.WriteLine(toDoProviderList.Result.Message);
                }

            }
            else
            {
                Console.WriteLine(toDoProviderList.Result.Message);
            }
        }
    }
}
